    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var fks = from et in modelBuilder.Model.GetEntityTypes()
                  from fk in et.GetForeignKeys()
                  where typeof(User).IsAssignableFrom(fk.PrincipalEntityType.ClrType)
                  select fk;
        foreach (var fk in fks)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
           
        }
        base.OnModelCreating(modelBuilder);
    }
