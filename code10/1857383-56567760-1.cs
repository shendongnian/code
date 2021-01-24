csharp
using MongoDB.Entities;
using System.Collections.Generic;
namespace StackOverflow
{
    public class Program
    {
        public class Parent : Entity
        {
            public Child[] Children { get; set; }
        }
        public class Child
        {
            public List<Friend> Friends { get; set; }
        }
        public class Friend
        {
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            DB.Index<Parent>()
              .Key(p => p.Children[-1].Friends[-1].Name, KeyType.Ascending)
              .Create();
        }
    }
}
the above creates an ascending index on the name field which is nested two levels deep with the following command:
java
db.Parent.createIndex({
    "Children.Friends.Name": NumberInt("1")
}, {
    name: "Children.Friends.Name(Asc)",
    background: true
})
