    protected override void OnModelCreating(DbModelBuilder modelBuilder) 
    {
        var types = GetTypesInheritingFrom(typeof (Audit)); 
        foreach (var t in types) 
        {
            var method = this.GetType().GetMethod("MapUserRelations");
            var generic = method.MakeGenericMethod(t, BindingFlags.NonPublic | BindingFlags.Instance);
            generic.Invoke(this, new Object[] { modelBuilder });
        }
    }
