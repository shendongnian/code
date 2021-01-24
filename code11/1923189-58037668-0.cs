csharp
    var res = collection.Find("{$expr:{$gt:['$Spent','$Budget']}}")
                        .ToList();
**MongoDB.Entities**:
csharp
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class Project : Entity
        {
            public decimal Budget { get; set; }
            public decimal Spent { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test", "localhost");
            (new Project
            {
                Budget = 10000,
                Spent = 11000
            }).Save();
            var res = DB.Find<Project>()
                        .MatchExpression("{$gt:['$Spent','$Budget']}")
                        .Execute();
        }
    }
}
