    modelBuilder.Entity<DetailedOrder>(entity =>
    {
        entity.HasBaseType((string)null)
            .Ignore(o => o.DetailedOrder);
        entity.HasKey(o => new { o.OrderId, o.Rev }); // <--
        entity.ToTable("Orders");
    });
    modelBuilder.Entity<Order>(entity =>
    {
        entity.HasKey(o => new { o.OrderId, o.Rev }); // <--
        entity.ToTable("Orders");
        entity.HasOne(o => o.DetailedOrder).WithOne()
            .HasForeignKey<Order>(o => new { Id = o.OrderId, o.Rev });
    });
