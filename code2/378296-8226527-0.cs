    public static IQueryable<TDest> ToDTO<TDest>(this IQueryable source)
    {
       return DTOTranslator<TDest>.ConvertToDTO<TDest>(source);
    }
    
    public static IQueryable<TDest> ConvertToDTO<TDest>(IQueryable source)
    {
        Type sourceType = null;
        ....
        foreach(var item in source)
        {
           // find source type is it not found till now
           if (sourceType == null)
             sourceType = item.GetType();
           ....
        }
    }
