 public class ApplicationUser
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ApplicationUser Provider { get; set; }
        public virtual List<ApplicationUser> Clients { get; set; }
        public virtual ApplicationUser Approver { get; set; }
        public virtual List<ApplicationUser> Candidates { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasOptional(e => e.Approver).WithMany(e=>e.Candidates);
            modelBuilder.Entity<ApplicationUser>().HasOptional(e => e.Provider).WithMany(e =>e.Clients);
        }
    }
