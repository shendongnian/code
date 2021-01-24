        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Assignee>(entity =>
            {
                entity.Property(e => e.AssigneeId).HasColumnName("AssigneeID");
            });
        }
