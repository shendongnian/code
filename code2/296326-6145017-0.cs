    Dictionary<string,object> searchParams = new Dictionary<string,object>();  
    searchParams.Add("q", "coffee");     
    searchParams.Add("center", "37.76,-122.427");     
    searchParams.Add("type", "place");     
    searchParams.Add("distance", "1000");
    
    FacebookClient fbClient = new FacebookClient(token);
    var searchedPlaces = fbClient.Get("/search", searchParams); 
