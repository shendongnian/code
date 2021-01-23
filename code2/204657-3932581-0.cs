    private static Expression<Func<Conference, bool>> GetSearchPredicate(string keyword, int? venueId, string month, int year)
    {
        if (!String.IsNullOrEmpty(keyword))
        {
            //return a filtering fonction
            return (conf)=> conf.Title.Contains(keyword) || Description.Contains(keyword)));
        }
        if (venueId.HasValue) 
        {
            // Some other predicate added...
            return (conf)=> /*something boolean here */;
        }
        
        //no matching predicate, just return a predicate that is always true, to list everything
        return (conf) => true;
    
    }
