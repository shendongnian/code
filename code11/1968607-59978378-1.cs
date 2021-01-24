    var creationTime = modelBuilder
        .Entity<Order>()
        .Property(e => e.CreationTime)
        .ValueGeneratedOnAddOrUpdate()
        .Metadata;
    creationTime.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
    creationTime.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
