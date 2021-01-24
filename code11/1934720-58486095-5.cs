    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
    public class Group
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
