    var q = SessionInstance.QueryOver<Person>();
    
    if (!String.IsNullOrEmpty(searchPersonDto.FirstName)) //necessary
       q = q.Where(p => p.FirstName.IsLike(searchPersonDto.FirstName, MatchMode.Anywhere));
    
    if (!String.IsNullOrEmpty(searchPersonDto.LastName))  //necessary
       q = q.Where(p => p.LastName.IsLike(searchPersonDto.LastName, MatchMode.Anywhere));
    
    var results = q.Fetch(p => p.Identity).Eager
        .List<Person>();
