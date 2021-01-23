    /// <summary> Constructor: Initializes a new ApplicationDbContext instance. </summary>
    public ApplicationDbContext()
            : base(MyApp.ConnectionString, throwIfV1Schema: false)
    {
        // Set the Kind property on DateTime variables retrieved from the database
        ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized +=
          (sender, e) => DateTimeKindAttribute.Apply(e.Entity, DateTimeKind.Utc);
    }
