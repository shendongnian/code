     protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          base.OnModelCreating(modelBuilder);
          modelBuilder.Entity<ApplicationUser>().Ignore(e => e.Email).Ignore(e => e.NormalizedEmail);
      }
