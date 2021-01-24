    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string filename = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                StreamReader csv = new StreamReader(filename);
                string line = "";
                List<Student> students = new List<Student>();
                while((line = csv.ReadLine()) != null)
                {
                    students.Add(new Student(line));
                }
                Console.ReadKey();
            }
        }
        class Student
        {
            public string name { get; set; }
            public double average { get; set; }
            public int social_number { get; set; }
            public Student(string csv_line)
            {
                if (csv_line != "")
                {
                    string[] chunks = csv_line.Split(';');
                    name = chunks[0];
                    average = Convert.ToDouble(chunks[1]);
                    social_number = Convert.ToInt32(chunks[2]);
                }
            }
        }
    }
