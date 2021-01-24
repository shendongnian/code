public class Program
    {
        public static void Main()
        {
            var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            var session = cluster.Connect();
            var User = new Table<User>(session, MappingConfiguration.Global, "users", "testks");
            User.CreateIfNotExists();
            var u = new User
            {
                Id = Guid.NewGuid(),
                Password = "123",
                FirstName = "123",
                LastName = "123",
                CommonName = "123",
                ProfilePhoto = "321",
                IsDeleted = false,
                UserRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        Text = "text"
                    }
                }
            };
            User.Insert(u).Execute();
            var result = User.First(l => l.Id == u.Id).Execute();
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.ReadLine();
            User.Where(l => l.Id == u.Id).Delete().Execute();
        }
    }
    public class User : IdentityUser<Guid>
    {
        [Cassandra.Mapping.Attributes.Ignore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CommonName { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsDeleted { get; set; }
        [Cassandra.Mapping.Attributes.Ignore]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
    public class IdentityUser<T>
    {
        [Cassandra.Mapping.Attributes.PartitionKey]
        public T Id { get; set; }
    }
    public class UserRole
    {
        public string Text { get; set; }
    }
Running the code above against Cassandra `3.0.18` with C# driver `3.10.1` seems to work correctly. The `Password` and `UserRoles` will not exist in the table schema and they will both be `null` when executing `SELECT` statements with `Linq2Cql`.
