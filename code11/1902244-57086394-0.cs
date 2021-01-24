java
db.Issue.update({
    "_id": ObjectId("5d2fd8e820f6a5274823cbee")
}, {
    "$set": {
        "Properties.prop2": "geh",
        "Properties.prop3": "xyz"
    }
})
here's the c# code that generated the above query. it's using my library MongoDB.Entities for brevity.
csharp
using MongoDB.Entities;
using System.Collections.Generic;
namespace StackOverflow
{
    public class Program
    {
        public class Issue : Entity
        {
            public IDictionary<string, string> Properties { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            var issue = new Issue
            {
                Properties = new Dictionary<string, string>
                    {
                        { "prop1", "abc" },
                        { "prop2", "def" }
                    }
            };
            issue.Save();
            DB.Update<Issue>()
              .Match(i => i.ID == issue.ID)
              .Modify(i => i.Properties["prop2"], "geh")
              .Modify(i => i.Properties["prop3"], "xyz")
              .Execute();
        }
    }
}
