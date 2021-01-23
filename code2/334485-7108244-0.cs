    public static DictionaryBuilder<RouteValueDictionary> IndexRoute 
    { 
        get 
        { 
            return new RouteValues()
                .WithValue("controller", "Admin")
                .WithValue("action", "Index"); 
        } 
    }
