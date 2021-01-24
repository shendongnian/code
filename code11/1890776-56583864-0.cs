csharp
using MongoDB.Entities;
using MongoDB.Driver.Linq;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class User : Entity
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string[] Roles { get; set; }
        }
        public class Role : Entity
        {
            public string Name { get; set; }
        }
        static void Main(string[] args)
        {
            new DB("test");
            var managerRole = new Role { Name = "Manager" };
            var superRole = new Role { Name = "Supervisor" };
            managerRole.Save();
            superRole.Save();
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Roles = new[] { managerRole.ID, superRole.ID }
            };
            user.Save();
            var findRoles = new[] { managerRole.ID, superRole.ID };
            var managers = DB.Queryable<User>()
                             .Where(u => u.Roles.Any(r => findRoles.Contains(r)))
                             .Select(u => u.FirstName + " " + u.LastName)
                             .ToArray();
        }
    }
}
here's the aggregation query it sends to mongodb:
java
db.User.aggregate([{
    "$match": {
        "Roles": {
            "$elemMatch": {
                "$in": ["5d02691bada517167415c326", "5d02691cada517167415c327"]
            }
        }
    }
}, {
    "$project": {
        "__fld0": {
            "$concat": ["$FirstName", " ", "$LastName"]
        },
        "_id": 0
    }
}])
