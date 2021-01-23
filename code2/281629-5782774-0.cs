    var predicate = PredicateBuilder.False<Community>();
    foreach(var s in searchTextLowerCase)
    {
        predicate = predicate.Or(x => x.Name.ToLower().Contains(s));
        predicate = predicate.Or(x => x.Acronym.ToLower().Contains(s))
        //.. etc
    }
    var filteredCommunities = communities.Where(predicate);
    
