     protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
    
                modelBuilder.Entity<User>()
                    .HasOne<UserProfile>(s => s.Profile)
                    .WithOne(s => s.User)
                    .HasForeignKey<UserProfile>(s=>s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<ApplicationInfo>()
                    .HasOne<UserProfile>(s => s.UserProfile)
                    .WithMany(s => s.ApplicationInfos)
                    .HasForeignKey(s => s.UserProfileId)
                    .OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<Review>()
                    .HasOne<UserProfile>(s => s.UserProfile)
                    .WithMany(s => s.Reviews)
                    .HasForeignKey(s => s.UserProfileId)
                    .OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<Review>()
                    .HasOne<ApplicationInfo>(s => s.ApplicationInfo)
                    .WithMany(s => s.Reviews)
                    .HasForeignKey(s => s.ApplicationInfoId)
                    .OnDelete(DeleteBehavior.Restrict);
    
                base.OnModelCreating(modelBuilder);
    
    
            }
