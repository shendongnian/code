    public static TDestination Map<TSource, TDestination>(this TDestination destination, TSource source)
    {
        if(source == null)
            return destination;
    
        return Mapper.Map(source, destination);
    }
