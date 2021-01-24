    public class QueryResultConverter<TSource, TDest>
    : ITypeConverter<IQueryResult<TSource>, IQueryResult<TDest>> where TSource: IBaseEntity where TDest : IBaseEntity
    {
        public IQueryResult<TDest> Convert(IQueryResult<TSource> source, IQueryResult<TDest> destination, ResolutionContext context)
        {
            List <TDest> payload = context.Mapper.Map<List<TDest>>(source.Payload);
            destination = new QueryResult<TDest>(payload, source.PageInfo);
    
            return destination;
        }
    }
