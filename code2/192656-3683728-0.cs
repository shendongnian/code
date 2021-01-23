    public void DeepLoad(ref T entity, Type[] childTypes)
    {
        
        Type baseType;
        HasBaseType(typeof (T), out baseType);
        var entitySetName = ProviderHelper.GetEntitySetName(Context, baseType.Name);
        var query = Context.CreateQuery<T>(entitySetName);
        foreach (var childType in ProviderHelper.GetChildTypeNames(childTypes).Split(','))
        {
            query = query.Include(childType);
        }
        entity = query.SingleOrDefault();
    }
