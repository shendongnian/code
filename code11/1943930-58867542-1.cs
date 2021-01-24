    modelBuilder.Entity<Transaction>
        .HasOne(x => x.Category)
        .WithMany()
        .IsRequired()
        .HasForeignKey("CategoryId");
    modelBuilder.Entity<Transaction>
        .HasOne(x => x.SubCategory)
        .WithMany()
        .IsRequired()
        .HasForeignKey("SubCategoryId");
