            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                modelBuilder.Entity<User>()
                    .HasMany(e => e.UserRole)
                    .WithRequired(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .WillCascadeOnDelete(true);
            }
