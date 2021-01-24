           modelBuilder.Entity<CategoryRelation>()
                  .HasKey(c => new { c.ParentId, c.ChildId });
            modelBuilder.Entity<CategoryRelation>()
                  .HasRequired(c => c.ParentCategory)
                  .WithMany(c => c.ChildCategoryList)
                  .HasForeignKey(c => c.ParentId)
                  .WillCascadeOnDelete(false);
            modelBuilder.Entity<CategoryRelation>()
                .HasRequired(c => c.ChildCategory)
                .WithMany(c => c.ParentCategoryList)
                .HasForeignKey(c => c.ChildId)
                .WillCascadeOnDelete(false);
