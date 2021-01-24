                modelBuilder.Entity<ProjectManager>()
                    .HasKey(ppm => new { ppm.ProjectID, ppm.AppUserID });
    
                modelBuilder.Entity<ProjectManager>()
                    .HasOne(pm => pm.AppUser)
                    .WithMany(p => p.ProjectsAsManager)
                    .HasForeignKey(pm => pm.AppUserID);
    
                modelBuilder.Entity<ProjectManager>()
                    .HasOne(pm => pm.Project)
                    .WithMany(p => p.ProjectManagers)
                    .HasForeignKey(pm => pm.ProjectID);
    
                base.OnModelCreating(modelBuilder);
