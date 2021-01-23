    public interface IQuery {
         IList GetData();
         Type QueryType { get; }
    }
    public interface IQuery<TModel> : IQuery
    {
        new IList<TModel> GetData();
    }    
    public interface IQueryProvider
    {
       List<IQuery> GetAllQueries();
    }
