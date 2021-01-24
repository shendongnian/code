    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataBase db = new DataBase()
                {
                    students = new List<Students>() {
                        new Students() { Id = 1, StudentId = 15, CourseName = "Biology 101"},
                        new Students() { Id = 2, StudentId = 21, CourseName = "English 201"},
                        new Students() { Id = 3, StudentId = 38, CourseName = "History 301"},
                        new Students() { Id = 4, StudentId = 41, CourseName = "Anthropology 401"},
                        new Students() { Id = 5, StudentId = 15, CourseName = "Graphics 210"},
                        new Students() { Id = 6, StudentId = 21, CourseName = "Physics Lab B"}
                    }
                };
                List<int> searchIds = new List<int>() { 15, 21 };
                List<Students> results = db.students.Where(x =>  searchIds.Contains(x.StudentId))
                    .GroupBy(x => x.StudentId)
                    .Select(x => x.FirstOrDefault())
                    .ToList();
            }
        }
        public class DataBase
        {
            public List<Students> students { get;set;}
        }
        public class Students
        {
            public int Id { get; set; }
            public int StudentId { get; set; }
            public string CourseName { get; set; }
        }
    }
