    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<DivAssignment>()
                    .HasRequired(c => c.CreatedByUser)
                    .WithMany(u => u.CreatedDivAssignments)
                    .HasForeignKey(c => c.CreatedByUserId)
                    .WillCascadeOnDelete(false);
                
                modelBuilder.Entity<DivAssignment>()
                    .HasRequired(c => c.LastModifiedByUser)
                    .WithMany(u => u.ModifiedDivAssignments)
                    .HasForeignKey(c => c.LastModifiedByUserId)
                    .WillCascadeOnDelete(false);
            }
