    private Collection<string> modelTypeNames;
    
    private Collection<string> ModelTypeNames
    {
        get
        {
            if (modelTypeNames == null)
            {
                // We'll figure out all the EF model types by simply returning all the type arguments of every DbSet<> property in the dbContext.
                modelTypeNames = new Collection<string>(typeof(VerhaalLokaalDbContext).GetProperties().Where(d => d.PropertyType.Name == typeof(DbSet<>).Name).SelectMany(d => d.PropertyType.GenericTypeArguments).Select(t => t.Name).ToList());
            }
    
            return modelTypeNames;
        }
    }
