    modelBuilder.Entity<Post>(entity =>
    {
        entity.HasOne<Category>(s => s.Category)
            .WithMany(c => c.Posts)
            //.HasForeignKey(s => s.PostId);
            .HasForeignKey(s => s.CategoryId);
        entity.HasOne<User>(s => s.User)
            .WithMany(u => u.Posts)
            //.HasForeignKey(s => s.PostId);
            .HasForeignKey(s => s.UserId);
        entity.Property(s => s.CreatedAt)
            .HasDefaultValueSql("SYSUTCDATETIME()");
    });
