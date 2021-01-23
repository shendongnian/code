    public virtual Type GetEntityType()
    {
        var type = GetType();
        // Hack to avoid problem with some types that always be proxy. 
        // Need re-evaluate when upgrade to NH 3.3.3
        return type.Name.EndsWith("Proxy") ? type.BaseType : type;
    }
    
    public virtual bool IsOfType<T>()
    {
        return typeof(T).IsAssignableFrom(GetEntityType());
    }
