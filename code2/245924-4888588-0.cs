    string[] words = { "cherry", "apple", "blueberry", "cherry", "cherry", "blueberry" };
    
    var topWordAndCount=words
        .GroupBy(w=>w)
        .OrderByDescending(g=>g.Count())
        .Select(g=>new {Word=g.Key,Count=g.Count()})
        .FirstOrDefault();
    //if(topWordAndCount!=null)
    //{
    //    topWordAndCount.Word
    //    topWordAndCount.Count
