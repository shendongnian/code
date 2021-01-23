    public IEnumerable<BlogPost> LoadPosts() 
    {
      var cacheService = new CachingService();
      var blogPosts = cacheService.Get<IEnumerable<BlogPost>>("BlogPosts");
    
      if (blogPosts == null)
      {
         blogPosts = postManager.LoadPostsFromDatabase();
         cacheService.Insert("BlogPosts", blogPosts);
      }
    
      return blogPosts;
    }
