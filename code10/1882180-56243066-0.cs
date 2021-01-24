csharp
using MongoDB.Driver.Linq;
using MongoDB.Entities;
using System.Linq;
namespace StackOverflow
{
    public class User : Entity
    {
        public string Name { get; set; }
        public Foo[] Foos { get; set; }
    }
    public class Foo
    {
        public string Plot { get; set; }
        public string Color { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("test");
            var user = new User
            {
                Name = "Jone Doe",
                Foos = new[]
                {
                    new Foo{ Plot = "circle", Color="yellow"},
                    new Foo{ Plot = "circle", Color="red"},
                    new Foo{ Plot = "square", Color="green"},
                }
            };
            user.Save();
            var circularFoos = DB.Collection<User>()
                                 .Where(u => u.Name == "Jone Doe")
                                 .SelectMany(u => u.Foos)
                                 .Where(f=>f.Plot=="circle").ToArray();
        }
    }
}
this is the aggregate query it generates:
json
  {
    "$match": {
      "Name": "Jone Doe"
    }
  },
  {
    "$unwind": "$Foos"
  },
  {
    "$project": {
      "Foos": "$Foos",
      "_id": 0
    }
  },
  {
    "$match": {
      "Foos.Plot": "circle"
    }
  }
