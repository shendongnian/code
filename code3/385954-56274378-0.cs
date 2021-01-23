csharp
using MongoDB.Driver.Linq;
using MongoDB.Entities;
using System.Linq;
namespace StackOverflow
{
    public class User : Entity
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DB("test");
            (new User { Name = "Bob" }).Save();
            var id = DB.Collection<User>()
                       .Where(u => u.Name == "Bob")
                       .Select(u => u.ID)
                       .First();            
        }
    }
}
mind you, the above code is using the mongodb wrapper library called [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities)
