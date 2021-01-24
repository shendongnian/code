csharp
using System;
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class Cage : Entity
        {
            public Guid PetID { get; set; } = Guid.Empty;
        }
        static void Main(string[] args)
        {
            new DB("test");
            var cage1 = new Cage { PetID = Guid.NewGuid() };
            cage1.Save();
            var cage2 = new Cage {};
            cage2.Save();
            var list = new[] { cage1.PetID, Guid.NewGuid(), Guid.NewGuid() };
            DB.Update<Cage>()
              .Match(f => f.In(c => c.PetID, list))
              .Modify(c => c.PetID, Guid.Empty)
              .Execute();
        }
    }
}
above code is using [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities) which is a convenience library for the c# driver. [disclaimer: i'm the author of the library]
