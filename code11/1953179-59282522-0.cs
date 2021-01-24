    // Your setting of a global file e.g. hides all as deleted marked items
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Type>().HasQueryFilter(b => !b.IsDeleted);
    }
    // Instead of creating two queries, you have to manually combine both cases into one query
    private void DoSomething()
    {
        var combined = context.Type.IgnoreQueryFilter().Include(b => b.Activity).Where(b => !b.accepted || !b.IsDeleted);
    }
