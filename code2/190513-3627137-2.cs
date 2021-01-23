    public interface ISuggestionRepository
    {
    	List<Suggestion> All { get; }
    }
    
    public class Repository<T>
    {
          public List<T> All 
    	  {
    	      get { return new List<T>(); }
    	  }
    }
    
    public class SuggestionRepository : Repository<Suggestion>, ISuggestionRepository
    { }
