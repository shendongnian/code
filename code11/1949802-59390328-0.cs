 C#
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var keys = builder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey());
        foreach (var key in keys)
        {
    
            foreach (var property in key.Properties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
                        
                    
        }
    }
