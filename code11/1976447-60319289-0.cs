    public class WikiSearchQuery{
         public Dictionary<string,WikiSearchPage> pages { get; set; }
    }
    
    public class WikiSearchPage{
         public int pageid { get; set; }
         public string title { get; set; }
    }
    
    public class WikiSearchResults{
         public WikiSearchQuery query { get; set; }
    }
