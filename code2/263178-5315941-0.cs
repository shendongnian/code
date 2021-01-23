    YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
    
    //order results by the number of views (most viewed first)
    query.OrderBy = "viewCount";
    
    // search for puppies and include restricted content in the search results
    // query.SafeSearch could also be set to YouTubeQuery.SafeSearchValues.Moderate
    query.Query = "puppy";
    query.SafeSearch = YouTubeQuery.SafeSearchValues.None;
    
    Feed<Video> videoFeed = request.Get<Video>(query);
    
    printVideoFeed(videoFeed);
