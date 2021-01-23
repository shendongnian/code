    var q = ...
            group r by r.TagName into g;
            select new
            {
                TagName = g.Key,
                Count = g.Count()
            }
    foreach (var i in q)
    {
        string tagName = g.TagName;
        int count = g.Count;    
    }    
