    using System;
    namespace test2
    {
        class Program
        {
            public class Student
            {
                public string Name { get; set; }
                public string Lastname { get; set; }
                public int Grade { get; set; }
            }
            static void Main(string[] args)
            {
                Student studentA = CreateStudent("John", "Park", 20);
                PrintStudent(studentA);
                Student studentB = CreateStudent("Joe", "Dor", 10);
                PrintStudent(studentB);
                Student studentC = CreateStudent("Rose", "Hancook", 7);
                PrintStudent(studentC);
                Console.ReadLine();
            }
            private static Student CreateStudent(string name, string lastName, int grade)
            {
                Student student = new Student
                {
                    Name = name,
                    Lastname = lastName,
                    Grade = grade
                };
                return student;
            }
            private static void PrintStudent(Student student)
            {
                Console.WriteLine($"Name: {student.Name} | Lastname: {student.Lastname} | Grade: {student.Grade}");
            }
        }
    }    
