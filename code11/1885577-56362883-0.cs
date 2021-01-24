        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(s => s.Products)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId);
        }
