    interface ISearchCo<out T> {
      T Result { get; }
    }
    interface ISearchContra<in T> {
      T Result { set; }
    }
    // ...
    public static ISearchCo<T> getSearchObject<T>() { 
      return (ISearchCo<T>)new FileSearch(); 
    } 
