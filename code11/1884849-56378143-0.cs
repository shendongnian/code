csharp
using MongoDB.Entities;
namespace StackOverflow
{
    class Program
    {
        public class Company : Entity
        {
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            DB.Index<Company>()
              .Key(c => c.Name, KeyType.Text)
              .Option(o => o.Background = false)
              .Create();
            var c1 = new Company { Name = "Ackme" };
            var c2 = new Company { Name = "Acme" };
            var c3 = new Company { Name = "Lackme" };
            var c4 = new Company { Name = "Hackme" };
            c1.Save(); c2.Save(); c3.Save(); c4.Save();
            var names = new[] { "ackme", "acme" };
            var result = DB.SearchText<Company>(string.Join(" ", names));
        }
    }
}
mind you, the above uses the convenience library [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities). however the concepts are the same but the syntax for the official driver is cumbersome compared to the above.
