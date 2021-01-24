        modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne<Category>(s => s.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(s => s.PostId);
                entity.HasOne<User>(s => s.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(s => s.PostId);
                entity.Property(s => s.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");
            });
