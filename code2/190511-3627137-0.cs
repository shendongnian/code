    public interface IRepository<T>
    {
    	List<T> All { get; }
    }
    
    public class Repository<T>
    {
          public List<T> All 
    	  {
    	      get { return new List<T>(); }
    	  }
    }
    
    public class SuggestionRepository : Repository<Suggestion>, IRepository<Suggestion>
    { }
