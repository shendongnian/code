    interface ISearchCo<out T> where T : SearchResult {
      T Result { get; }
    }
    interface ISearchContra<in T> where T : SearchResult {
      T Result { set; }
    }
    // ...
    public ISearchCo<SearchResult> getSearchObject() { 
      return (ISearchCo<SearchResult>)new FileSearch(); 
    } 
