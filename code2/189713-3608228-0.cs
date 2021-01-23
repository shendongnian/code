    var blogDict = blogs.ToDictionary(b => b.Id);
    
    foreach(var group in tagJunk.GroupBy(j => j.Fk_Blog_Id)) {
      if (blogDict.ContainsKey(group.Key)) {
        var blog = blogDict[group.Key];
        foreach (var junction in group) {
          // here you have the blog and the junction
        }
      }
    }
