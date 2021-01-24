    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System.Linq;
    namespace StackOverflow
    {
        public class TestSession : Entity
        {
            public string Name { get; set; }
            [BsonRepresentation(BsonType.ObjectId)]
            public string TaskID { get; set; }
            [BsonIgnore]
            public TaskConfiguration Task { get; set; }
        }
        public class TaskConfiguration : Entity
        {
            public int NumOfIterations { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test");
                var task = new TaskConfiguration { NumOfIterations = 10 };
                task.Save();
                var session = new TestSession { Name = "This is a test session", TaskID = task.ID };
                session.Save();
                var res = DB.Queryable<TestSession>()
                            .Where(t => t.ID == session.ID)
                            .Join(
                                DB.Queryable<TaskConfiguration>(),
                                s => s.TaskID,
                                c => c.ID,
                                (s, c) => new TestSession
                                {
                                    ID = s.ID,
                                    Name = s.Name,
                                    TaskID = s.TaskID,
                                    Task = c
                                })
                            .Single();
            }
        }
    }
