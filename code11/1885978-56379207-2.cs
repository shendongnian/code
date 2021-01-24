    public partial class ContactDBContext : DbContext {
        public ContactDBContext(DbContextOptions<ContactDBContext> options)
            : base(options) {
        }
        public virtual DbSet<Contacts> Contacts { get; set; }
        }
    }
