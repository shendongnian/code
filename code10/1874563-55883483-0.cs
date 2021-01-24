        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
              modelBuilder.Entity<Album>()
                            .ToTable("Albums");
        }
           
        
      
