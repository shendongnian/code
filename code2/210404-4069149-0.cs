    public class SearchViewModel
    {
       ...
    
       private string search;
       
       public string Search
       {
          get
          {
             return search;
          }
          set
          {
             search = value.Trim();
          }
       }
    
       ...
    }
