    public class ContactContext : DbContext
        {
            public ContactContext() : base() { }
    
            public DbSet Contacts { get; set; }
        }
