    public class RazorpagesCoreContext : DbContext
    {
        public RazorpagesCoreContext (DbContextOptions<RazorpagesCoreContext> options)
            : base(options)
        {
        }
        
        public DbSet<Officer> Officer { get; set; }
        public DbSet<SecurityLog> SecurityLog { get; set; }
        public DbSet<SecurityLogOfficer> SecurityLogOfficer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecurityLogOfficer>()
                .HasKey(t => new { t.SecurityLogID, t.OfficerID });
            modelBuilder.Entity<SecurityLogOfficer>()
                .HasOne(pt => pt.SecurityLog)
                .WithMany(p => p.SecurityLogOfficers)
                .HasForeignKey(pt => pt.SecurityLogID);
            modelBuilder.Entity<SecurityLogOfficer>()
                .HasOne(pt => pt.Officer)
                .WithMany(t => t.SecurityLogOfficers)
                .HasForeignKey(pt => pt.OfficerID);
        }
    }
