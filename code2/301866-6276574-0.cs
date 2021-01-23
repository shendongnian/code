    public interface Query<out TModel>
    {
    	IEnumerable<TModel> GetData();
    }
    
    public interface IQueryProvider
    {
       List<Query<object>> GetAllQueries();
    }
