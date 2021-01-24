    public class FamilyDbContext
    {
        public DbSet<Parent> Parents {get; set;}
        public DbSet<Child> Children {get; set;}
        public DbSet<Child2> Children2 {get; set;}
    }
