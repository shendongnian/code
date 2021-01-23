    public class User
    {
        public virtual string IdUser { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }
    
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.IdUser);
            Map(x => x.Email);
            Map(x => x.Name);
            Map(x => x.Password);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("data.db3"))
            {
                File.Delete("data.db3");
            }
    
            using (var factory = CreateSessionFactory())
            {
                using (var connection = factory.OpenSession().Connection)
                {
                    ExecuteQuery("create table Users(IdUser string primary key, Name string, Email string, Password string)", connection);
                }
    
                using (var session = factory.OpenSession())
                using (var tx = session.BeginTransaction())
                {
                    session.Save(new User()
                    {
                        IdUser = "adapol",
                        Name = "Adam Mickiewicz",
                        Email = "adamm@wp.pl",
                    });
                    tx.Commit();
                }
            }
        }
    
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard.UsingFile("data.db3").ShowSql()
                )
                .Mappings(
                    m => m.FluentMappings.AddFromAssemblyOf<UserMap>()
                )
                .BuildSessionFactory();
        }
    
        static void ExecuteQuery(string sql, IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
