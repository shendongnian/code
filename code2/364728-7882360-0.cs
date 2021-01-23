    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<Company> Companies { get; set; }
        public User()
        {
            Companies = new List<Company>();
        }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class POCOEntitiesContext : ObjectContext
    {
        private ObjectSet<User> users;
        public ObjectSet<User> Users
        {
            get { return users; }
        }
        private ObjectSet<Company> companies;
        public ObjectSet<Company> Companies
        {
            get { return companies; }
        }
        public POCOEntitiesContext() : base("name=POCOEntities", "POCOEntitiesContainer")
        {
            users = CreateObjectSet<User>();
            companies = CreateObjectSet<Company>();
        }
    }
    using (var ctx = new POCOEntitiesContext())
    {
        var loadedUser = ctx.Users.Where(u => u.Username == "Peri").First();
        loadedUser.Companies.Add(new Company() { Name = "New Company" });
        ctx.SaveChanges();
    }
