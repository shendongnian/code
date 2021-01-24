    class MyContext : DbContext
    {
        public DbSet<Box> Box { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Box>()
                .Property(p => p.Volume)
                .HasComputedColumnSql("[Height] * [Width] * [Depth]");
        }
    }
