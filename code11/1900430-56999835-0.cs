java
db.Property.createIndex({"TenantNames": "text"},{"background":false})
java
db.Property.find({
    "$text": {
        "$search": "smith",
        "$caseSensitive": false
    }
})
here's the c# code that generated the above queries. it uses my library MongoDB.Entities for brevity.
csharp
using MongoDB.Entities;
using System;
namespace StackOverflow
{
    public class Program
    {
        public class Property : Entity
        {
            public string TenantNames { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            DB.Index<Property>()
              .Key(p => p.TenantNames, KeyType.Text)
              .Option(o => o.Background = false)
              .Create();
            (new[] {
                new Property { TenantNames = "Maggie Smith" },
                new Property { TenantNames = "Smith Clein" },
                new Property { TenantNames = "marcus smith stein" },
                new Property { TenantNames = "Frank Bismith" }
            }).Save();
            var result = DB.SearchText<Property>("smith");
            foreach (var property in result)
            {
                Console.WriteLine(property.TenantNames);
            }
            Console.Read();
        }
    }
}
