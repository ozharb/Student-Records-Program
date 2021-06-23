using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentRecords
{
    public class Student
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string id { get; set; }
    }

    class MainClass
    {
        public static string[] answers = { "sure", "yes", "y", "yes!", "why not?", "why not", "definitely", "for sure", "absolutely", "I guess", "okay", "ok", "k" };
        public static string[] noAnswers = { "no", "n", "nah", "naw", "no!", "don't", "Noo", "not" };
        public static Student AddStudent()
        {
            Console.WriteLine("Please enter student's name");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter student's email");
            var email = Console.ReadLine();
            Console.WriteLine("Please enter student's age");
            var age = Console.ReadLine();

            var student = new Student
            {
                Name = name,
                Email = email,
                Age = age
            };
            Console.WriteLine("\n Record Added Successfully. \n");
            return student;
        }


        public static void ShowAllRecords(List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("\nThere are no records.\n");
                return;
            }


            int i = 1;
            Console.WriteLine($"\n Showing ALL ({list.Count}) Student Records: \n");
            foreach (Student student in list)
            {
                StudentRecordLine(student);
                i++;
            }
            Console.WriteLine("\n Done \n");

        }
        public static void ShowSpecificRecord(List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("\nThere are no records.\n");
                return;
            }

            Console.WriteLine("Enter student id, name, or email:");

            var input = Console.ReadLine();

            foreach (Student student in list)
            {
                if (student.Name == input || student.Email == input || student.id == input)
                {
                    Console.WriteLine("\n........................\n" +
                        "\nMATCH found: \n");
                    StudentRecordLine(student);
                    Console.WriteLine("\n........................\n");
                    return;
                }
            }
            Console.WriteLine("No match found. \n");


        }
        public static bool ContainsStudent(List<Student> list, string input)
        {
            foreach (Student student in list)
            {
                if (student.Name == input || student.Email == input || student.id == input)
                {

                    return true;
                }

            }
            return false;
        }

        public static void deleteRecord(List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("\nThere are no records.\n");
                return;
            }

            Console.WriteLine("Enter student ID, NAME, or EMAIL:");
            var input = Console.ReadLine();
            foreach (Student student in list)
            {
                if (student.Name == input || student.Email == input || student.id == input)
                {
                    Console.WriteLine("\n........................\n");
                    Console.WriteLine("Match found:\n");
                    StudentRecordLine(student);
                    Console.WriteLine("\n........................");
                    var confirming = true;
                    while (confirming)
                    {
                        Console.WriteLine("DELETE record?");
                        var isDeleting = Console.ReadLine();
                        if (answers.Contains(isDeleting.ToLower()))
                        {
                            list.Remove(student);
                            Console.WriteLine("\n Record Deleted. \n");
                            confirming = false;

                        }
                        else if (noAnswers.Contains(isDeleting.ToLower()))
                        {
                            Console.WriteLine("\n Deletion Request Canceled. \n");
                            confirming = false;

                        }
                        else
                        {
                            Console.WriteLine("\n Invalid Input.\n");

                        }
                    }
                    return;

                }


            }
            Console.WriteLine("\n No match found. \n");

        }
        public static void StudentRecordLine(Student student)
        {
            Console.WriteLine($"Name: {student.Name} | Email: {student.Email} | Age: {student.Age} | Id: {student.id}");
        }
        public static void UpdateRecord(List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("\nThere are no records.\n");
                return;
            }

            Console.WriteLine("Enter student ID, NAME, or EMAIL:");
            var input = Console.ReadLine();
            foreach (Student student in list)
            {
                if (student.Name == input || student.Email == input || student.id == input)
                {
                    Console.WriteLine("\n........................\n");
                    Console.WriteLine("Match Found:");
                    StudentRecordLine(student);
                    Console.WriteLine("\n........................\n");

                    var confirming = true;
                    while (confirming)
                    {
                        Console.WriteLine("Update record?");
                        var isUpdating = Console.ReadLine();
                        if (answers.Contains(isUpdating.ToLower()))
                        {
                            Console.WriteLine("\n Select number of value to update:\n" +
                                "1) Name \n" +
                                "2) Email \n" +
                                "3) Age \n" +
                                "4) Id");
                            var isSelecting = true;
                            while (isSelecting)
                            {

                                var selection = Convert.ToInt32(Console.ReadLine());

                                switch (selection)
                                {
                                    case 1:
                                        Console.WriteLine("Enter Name:"); //name
                                        student.Name = Console.ReadLine();
                                        isSelecting = false;
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter Email:"); //email
                                        student.Email = Console.ReadLine();
                                        isSelecting = false;
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter Age:");//age
                                        student.Age = Console.ReadLine();
                                        isSelecting = false;
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter ID:"); //id
                                        student.id = Console.ReadLine();
                                        isSelecting = false;
                                        break;
                                    default:
                                        Console.WriteLine("invalid input");
                                        break;
                                }

                                Console.WriteLine("\n =============== \n");
                                Console.WriteLine("Record Updated: \n");
                                StudentRecordLine(student);
                                Console.WriteLine("\n =============== \n");
                                confirming = false;
                            }

                        }
                        else if (noAnswers.Contains(isUpdating.ToLower()))
                        {
                            Console.WriteLine("\n Update Request Canceled. \n");
                            confirming = false;

                        }
                        else
                        {
                            Console.WriteLine("\n Invalid Input.\n");

                        }
                    }
                    return;

                }

            }
            Console.WriteLine("\n No match found. \n");

        }

        public static void SeedRecords(List<Student> list)
        {
            list.Add(new Student { Name = "Leonardo", Age = "29", Email = "Leo@sollers.edu", id = "1" });
            list.Add(new Student { Name = "Michelangelo", Age = "29", Email = "Michelangelo@sollers.edu", id = "2" });
            list.Add(new Student { Name = "Donatello", Age = "29", Email = "Don@sollers.edu", id = "3" });
            list.Add(new Student { Name = "Raphael", Age = "29", Email = "Raph@sollers.edu", id = "4" });
        }
        public static int StudentMenu()
        {
            Console.WriteLine("\n**** Menu ****\n" +
                "Please choose from the following options: \n" +
                "1-Show All Student Details, \n" +
                "2-Show Single Student Details, \n" +
                "3-Add Student Details,\n" +
                "4-Update Student Details,\n" +
                "5-Delete Student Details,\n" +
                "6-Exit. \n" +
                "***** End *****");

            var response = Convert.ToInt32(Console.ReadLine());
            return response;
        }
        public static void StudentSwitch(int selection, List<Student> list)
        {

            switch (selection)
            {
                case 1:
                    ShowAllRecords(list);//show all
                    break;
                case 2:
                    ShowSpecificRecord(list);//show single
                    break;
                case 3:
                    var student = AddStudent();//Add
                    student.id = Convert.ToString(list.Count + 1);
                    list.Add(student);
                    break;
                case 4:
                    UpdateRecord(list);//update
                    break;
                case 5:
                    deleteRecord(list);//delete
                    break;
                case 77:
                    SeedRecords(list);//seed data
                    break;
                default:
                    Console.WriteLine("invalid selection");
                    break;

            }

        }
        public static void StudentProgram()
        {
            var list = new List<Student>();
            var dontExit = true;

            while (dontExit)
            {
                var selection = StudentMenu();
                if (selection == 6)
                {
                    Console.WriteLine("Goodbye");
                    dontExit = false;
                }
                else
                {
                    StudentSwitch(selection, list);
                }
            }

        }


        public static void Main(string[] args)
        {
            StudentProgram();
        }
    }
}
