LazyloadingEnabled = false;
    
    public IEnumerable<BlogDbModel> GetBlogs()
    {
        return _dbContext.Blogs.ToList();
    }
    public IEnumerable<BlogDbModel> GetBlogsAndPosts()
    {
    
      return _dbContext.Blogs.Include("Posts").ToList();
    }
    //This will fetch only what is needed (You can customize to get columns what is needed)
    public IEnumerable<NewCustomDTO> GetBlogsAndPostCount()
    {
    
       return _dbContext.Blogs.Select(x=> NewCustomDTO
       {
           BlogName = x.BlogName,
           Count = x.Posts.Count(),
       });
    }
