    public class Zone 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Zone> Neighours { get; set; }
    }
    
    public class Context : DbContext
    {
        public DbSet<Zone> Zones { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>()
                        .HasMany(z => z.Neighbours)
                        .WithMany();
        }
    }
 
