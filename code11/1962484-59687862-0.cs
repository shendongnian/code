    public static T Select<T>(this Document document) where T : class, IGeneric
    {
        var t = typeof(T);
        switch (true)
        {
            case var _ when t.IsAssignableFrom(typeof(IWire)):
                return document.SelectEntity(EntityType.Wire) as T;
            case var _ when t.IsAssignableFrom(typeof(ISurface)):
                return document.SelectEntity(EntityType.Surface) as T;
            case var _ when t.IsAssignableFrom(typeof(ISolid)):
                return document.SelectEntity(EntityType.Solid) as T;
            default:
                return null;
        }
    }
