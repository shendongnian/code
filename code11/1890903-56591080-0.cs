csharp
using MongoDB.Entities;
using MongoDB.Driver;
using System;
namespace StackOverflow
{
    public class Program
    {
        public class User : Entity
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            DB.Index<User>()
              .Key(u => u.FirstName, KeyType.Text)
              .Key(u => u.LastName, KeyType.Text)
              .Create();
            DB.Index<User>()
              .Key(u => u.Age, KeyType.Ascending)
              .Create();
            var indexes = DB.Collection<User>().Indexes.List().ToList();
            foreach (var index in indexes)
            {
                Console.WriteLine(index.GetElement("name"));
            }
            Console.Read();
        }
    }
}
