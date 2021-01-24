    using System;
    using System.Collections.Generic;
    namespace Test
    {
        internal class Student
        {
            public int Id { get; set; }
            public int Mark { get; set; }
        }
        public static class Program
        {
            private readonly static IList<Student> StudentList = new List<Student>()
            {
                new Student { Id = 1, Mark = 55 },
                new Student { Id = 2, Mark = 65 },
                new Student { Id = 4, Mark = 75 },
                new Student { Id = 1, Mark = 65 },
                new Student { Id = 2, Mark = 45 }
            };
            private static IDictionary<int, int> Totals = new Dictionary<int, int>();
            public static void Main(string[] args)
            {
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
