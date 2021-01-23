    public void Search(SearchTerms Query)
    {
    var a = from b in db.branches
            where (b.Location != null) ?
            (
                (Query.Location == null) ?
                true
                :
                //The following line causes the exception to be thrown
                Query.Location.ToLower() == b.Location.ToLower()
    
            )
            : 
            (
                (Query.Location == null) ?
                true
                :
                false
           )
           select b
    }
