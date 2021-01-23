    public static class QueryableExtensions
    {
        public static IQueryable<TDest> ToDTO<TDest, TSource>(this IQueryable<TSource> source)
        {
            return DTOTranslator<TSource>.ConvertToDTO<TDest>(source);
        }
    }
