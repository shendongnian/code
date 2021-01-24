    protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<ProjectArea>().HasKey(projectArea => new { projectArea.ProjectId, projectArea.AreaId });
                      modelBuilder.Entity<Project>().HasMany(c => c.ProjectArea)
       .WithRequired()
       .HasForeignKey(c => c.ProjectId);
                   modelBuilder.Entity<Area>().HasMany(c => c.ProjectArea)
       .WithRequired()
       .HasForeignKey(c => c.AreaId);
        }
