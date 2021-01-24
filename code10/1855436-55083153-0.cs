    using System;
    using System.Collections.Generic;
    namespace Test
    {
        public class Student
        {
            public int Id { get; set; }
            public int Mark { get; set; }
        }
        public static class Program
        {
            private static List<Student> StudentList = new List<Student>();
            private static IDictionary<int, int> Totals = new Dictionary<int, int>();
            public static void Main(string[] args)
            {
                StudentList.Add(new Student { Id = 1, Mark = 55 });
                StudentList.Add(new Student { Id = 2, Mark = 65 });
                StudentList.Add(new Student { Id = 4, Mark = 75 });
                StudentList.Add(new Student { Id = 1, Mark = 65 });
                StudentList.Add(new Student { Id = 2, Mark = 45 });
                // Group sums per id
                foreach (var student in StudentList)
                {
                    var id = student.Id;
                    if (!Totals.ContainsKey(id))
                    {
                        Totals[id] = 0;
                    }
                    Totals[id] += student.Mark;
                }
                // Output sums
                foreach (var result in Totals)
                {
                     Console.WriteLine($"{result.Key} {result.Value}");
                }
            }
        }
    }
