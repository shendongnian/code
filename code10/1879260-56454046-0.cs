java
db.Parents.update(
    {
        "_id": ObjectId("5cf7391a1c86292244c4424e"),
        "ChildrenA": {
            "$elemMatch": {
                "_id": ObjectId("5cf7391a1c86292244c4424c")
            }
        }
    },
    {
        "$set": {
            "ChildrenA.$.Property": "UPDATED",
            "PropertyA": "UPDATED",
            "ChildrenB.0.Property": "UPDATED",
            "ChildrenB.1.Property2": "UPDATED"
        }
    }
)
as you can see you have to use `$elemMatch` to target a nested child by ID. and from what i can tell you can only have one $elemMatch in a single update command (correct me if i'm wrong).
here's the c# code that generated the above update command. it is using [MongoDB.Entities](https://github.com/dj-nitehawk/MongoDB.Entities) which is a convenience library which i'm the author of.
csharp
using MongoDB.Entities;
namespace StackOverflow
{
    public class Program
    {
        public class Parent : Entity
        {
            public ChildA[] ChildrenA { get; set; }
            public string PropertyA { get; set; }
            public string PropertyB { get; set; }
            public ChildB[] ChildrenB { get; set; }
        }
        public class ChildA : Entity
        {
            public string Property { get; set; }
            public string Property2 { get; set; }
        }
        public class ChildB
        {
            public string Property { get; set; }
            public string Property2 { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            var childA = new ChildA { Property = "update-me", Property2 = "leave-me-alone" };
            var childB = new ChildA { Property = "leave-alone", Property2 = "update-me" };
            childA.Save(); childB.Save();
            var parent = new Parent
            {
                ChildrenA = new[] { childA, childB },
                PropertyA = "update-me",
                PropertyB = "leave-me-alone",
                ChildrenB = new[] {
                new ChildB{ Property = "update-me", Property2 = "leave-me-alone"},
                new ChildB{ Property = "leave-alone", Property2 = "update-me"}
                }
            };
            parent.Save();
            DB.Update<Parent>()
              .Match(
                f => f.Eq(p => p.ID, parent.ID) &
                f.ElemMatch(
                    x => x.ChildrenA, 
                    x => x.ID == childA.ID))
              .Modify(x => x.ChildrenA[-1].Property, "UPDATED")
              .Modify(x => x.PropertyA, "UPDATED")
              .Modify(x => x.ChildrenB[0].Property, "UPDATED")
              .Modify(x => x.ChildrenB[1].Property2, "UPDATED")
              .Execute();
        }
    }
}
