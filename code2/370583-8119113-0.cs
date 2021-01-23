    public static void KeyColumnFromReference<T, TChild>(
        this OneToManyPart<TChild> collectionmap, ClassMap<T> map, Expression<Func<T, object>> referenceprop)
    {
        string propertyname = GetPropertyName(referenceprop);
        var column = ((IMappingProvider)map).GetClassMapping()
            .References.First(m => m.Name == propertyname)
            .Columns.First().Name;
        collectionmap.KeyColumn(column);
    }
    public static void KeyColumnFromReference<TChild, T>(
        this OneToManyPart<TChild> collectionmap, ClassMap<T> map)
    {
        var column = ((IMappingProvider)map).GetClassMapping()
            .References.First(m => m.Type == typeof(TChild))
            .Columns.First().Name;
        collectionmap.KeyColumn(column);
    }
    public UserMap()
    {
        HasMany(x => x.Items)
            .KeyColumnFromReference(new UserMap());
        // or
        HasMany(x => x.Items)
            .KeyColumnFromReference(new UserMap(), u => u.Owner);
    }
