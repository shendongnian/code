    public IObjectSet<T> GetEntitySet<T>() where T : class
    {
       var entityName = _plularizer.Pluralize(typeof(T).Name);
       string entitySetName = string.Format("{0}.{1}", EntityContainerName, entityName);
       return CreateObjectSet<T>(entitySetName );
    }
