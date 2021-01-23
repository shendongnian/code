    public static ObjectQuery<Fruit> IncludeAssocs(
        this ObjectQuery<Fruit> source, Enum[] assocs) 
    {
        foreach(var assoc in assocs)
        {
            query = query.Include(assoc.ToAssociationQueryString());
        }
    }
