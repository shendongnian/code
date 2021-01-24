java
db.Project.createIndex(
    {
        "WORKER": "text",
        "TRABAJADOR": "text"
    },
    {
        "background": false,
        "default_language": "none"
    }
)
java
db.Project.find({
    "$text": {
        "$search": "jesus",
        "$caseSensitive": false
    }
})
here's the c# code that generated the above queries. i'm using my library MongoDB.Entities for brevity.
csharp
using MongoDB.Entities;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Project : Entity
        {
            public string WORKER { get; set; }
            public string TRABAJADOR { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            DB.Index<Project>()
              .Key(p => p.WORKER, KeyType.Text)
              .Key(p => p.TRABAJADOR, KeyType.Text)
              .Option(o => o.DefaultLanguage = "none")
              .Option(o => o.Background = false)
              .Create();
            (new[] {
                new Project { WORKER = "JESUS HERNANDEZ DIAZ"},
                new Project { TRABAJADOR = "JESÚS HERNÁNDEZ DÍAZ"}
            }).Save();
            var result = DB.SearchText<Project>("jesus");
            Console.WriteLine($"found: {result.Count()}");
            Console.Read();
        }
    }
}
