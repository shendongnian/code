    var posts =
      context.Posts.
      //Include("Comments").
        ToDictionary(
          (p) => p, 
          (p) => p.Comments.Where((c)=> c.Votes.All((v) => v.VoteTypeId !=4))
        );
    foreach (var item in posts)
    {
      var post = item.Key;
      var comments = item.Value;
    }
