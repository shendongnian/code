    List<BOUserShoutoutResponseData> result = conList
      .AsParallel() // Same Linq but doing in parallel
    //.AsOrdered()  // uncomment if you want to preserve items' order
      .Select(//TODO: check totalShoutoutImages usage
              con => new BOUserShoutoutResponseData() { 
                UserName     = string.Join(" ", con.FirstName, con.LastName),
                PostTypeId   = con.PostTypeId ?? 0,
                PostType     = con.PostTypeName ?? string.Empty,
                Description  = con.Description ?? string.Empty,
                TotalLike    = (int)con.TotalLike,
                TotalComment = (int)con.TotalComment
                ... 
              })
      .ToList();
    
    return result;
