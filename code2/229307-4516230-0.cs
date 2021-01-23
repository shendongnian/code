    using (var context = new Model1Container())
    {
      var posts = context.Posts.
        All((p)=> p.Votes.All((v) => v.VoteTypeId!=4));
      //Or
      var posts2 = from p in context.Posts
              where p.Votes.All((v)=> v.VoteTypeId != 4)
              select p;                
    }
