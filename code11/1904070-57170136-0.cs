csharp
using MongoDB.Entities;
using System.Linq;
namespace StackOverflow
{
    public class Program
    {
        public class Account : Entity
        {
            public string Name { get; set; }
            public Many<User> Users { get; set; }
            public Account() => this.InitOneToMany(() => Users);
        }
        public class User : Entity
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public One<Account> Account { get; set; }
            [Ignore]
            public string AccountName { get; set; }
        }
        private static void Main(string[] args)
        {
            new DB("test");
            var account = new Account { Name = "parent account" };
            account.Save();
            var user = new User
            {
                FirstName = "dave",
                LastName = "mathews",
                Account = account.ToReference()
            };
            user.Save();
            account.Users.Add(user);
            //find parent by ID
            var parent = DB.Find<Account>().One(account.ID);
            //get first user of parent
            var dave = parent.Users.ChildrenQueryable()
                                   .FirstOrDefault();
            //get dave's account
            var davesAccount = dave.Account.ToEntity();
            //get dave with account name filled in by a single mongo query
            var daveExtra = (from u in DB.Queryable<User>().Where(u => u.ID == dave.ID)
                             join a in DB.Queryable<Account>() on u.Account.ID equals a.ID
                             select new User
                             {
                                 ID = u.ID,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 AccountName = a.Name
                             }).SingleOrDefault();
        }
    }
}
