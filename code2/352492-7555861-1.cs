     public partial class PersonModelContainer : DbContext
        {
            public PersonModelContainer()
                : base("name=PersonModelContainer")
            {
            }
        
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }
        
            public DbSet<Contact> Contacts { get; set; }
        }
