java
db.User.aggregate({
    "$match": {
        "Tokens": {
            "$elemMatch": {
                "TokenNumber": "234"
            }
        }
    }
})
here's the c# code that generated the above aggregation pipeline. it's using [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities) which is just a wrapper for the official driver. [disclaimer: i'm the author]
csharp
using MongoDB.Entities;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class User : Entity
        {
            public string Email { get; set; }
            public Token[] Tokens { get; set; }
        }
        public class Token
        {
            public string TokenNumber { get; set; }
            public bool Valid { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            (new User
            {
                Email = "email@domain.com",
                Tokens = new[] {
                    new Token{ TokenNumber="123",Valid = false },
                    new Token{ TokenNumber="234",Valid = true },
                    new Token{ TokenNumber="456",Valid = false },
                }
            }).Save();
            var user = DB.Queryable<User>()
                         .Where(u => u.Tokens.Any(t => t.TokenNumber == "234"))
                         .Single();
        }
    }
}
**EDIT:** 
since you mentioned you are unable to use the library, the following would be how to do it with the official driver:
csharp
var filter = Builders<User>.Filter
                           .ElemMatch(u => u.Tokens, 
                                      t => t.TokenNumber == "234");
var user = collection.Find(filter)
                     .Single();
csharp
var user = collection.Aggregate()
                     .Match(u => u.Tokens.Any(t => t.TokenNumber == "234"))
                     .ToList()
                     .Single();
csharp
var user = collection.AsQueryable()
                     .Where(u => u.Tokens.Any(t => t.TokenNumber == "234"))
                     .Single();
