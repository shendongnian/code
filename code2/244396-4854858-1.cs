    public void CreatePost(Post post, ILimit limit)
    {
        if(limit.IsLimitReached())
        {
          // do stuff
        }
    }
