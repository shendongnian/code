    using MongoDB.Driver;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Linq;
    namespace StackOverflow
    {
        public class Student : Entity
        {
            public string Name { get; set; }
            public string[] CoursesTaken { get; set; }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                new DB("test", "localhost");
                (new Student
                {
                    Name = "Harry Potter",
                    CoursesTaken = new[] { "spells", "broomsticks", "avacados" }
                }).Save();
                var query = DB.Fluent<Student>()
                              .Project(s => new
                              {
                                  s.ID,
                                  s.Name,
                                  s.CoursesTaken,
                                  lastCourse = s.CoursesTaken.Last()
                              })
                              .Match(x => x.lastCourse == "avacados")
                              .Project(x => new Student
                              {
                                  ID = x.ID,
                                  Name = x.Name,
                                  CoursesTaken = x.CoursesTaken
                              })
                              .ToList();            
            }
        }
    }
