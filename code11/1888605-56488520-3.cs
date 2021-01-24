modelBuilder.Entity<Category>(entity =>
{
    entity.HasMany<Post>(c => c.Posts)
        .WithOne(s => s.Category)
        //.HasForeignKey(c => c.PostId)     // remove this line
        .HasForeignKey(c => c.CategoryId)   // add this line
        .OnDelete(DeleteBehavior.Restrict);
    entity.Property(c => c.CreatedAt)
        .HasDefaultValueSql("SYSUTCDATETIME()");
});
