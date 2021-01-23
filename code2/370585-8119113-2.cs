    public static void KeyColumnFromReference<TChild>(
        this OneToManyPart<TChild> collectionmap, ClassMap<TChild> map, Expression<Func<TChild, object>> referenceprop)
    {
        string propertyname = GetPropertyName(referenceprop);
        var column = ((IMappingProvider)map).GetClassMapping()
            .References.First(m => m.Name == propertyname)
            .Columns.First().Name;
        collectionmap.KeyColumn(column);
    }
    public static void KeyColumnFromReference<T, TChild>(
        this OneToManyPart<TChild> collectionmap, ClassMap<TChild> map)
    {
        var column = ((IMappingProvider)map).GetClassMapping()
            .References.First(m => m.Type == typeof(TChild))
            .Columns.First().Name;
        collectionmap.KeyColumn(column);
    }
    public UserMap()
    {
        HasMany(x => x.Items)
            .KeyColumnFromReference<User, Item>(new ItemMap());
        // or
        HasMany(x => x.Items)
            .KeyColumnFromReference(new ItemMap(), u => u.Owner);
    }
