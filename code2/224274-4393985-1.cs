    public static ObjectQuery<Fruit> IncludeAssocs<T>(
        this ObjectQuery<Fruit> source, T[] assocs) 
        where T : struct, IComparable, IFormattable, IConvertible
    {
        if(!typeof(T).IsEnum) throw new ArgumentOutOfRangeException();
        foreach(T assoc in assocs)
        {
            query = query.Include(((Enum)assoc).ToString());
        }
    }
