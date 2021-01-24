    public Post Create(Guid blogId)
    {
        var blog = _context.Blogs.Include(t=>t.Posts).FirstOrDefault(x => x.Id == blogId);
        var postFactory = new PostFactory();
        var post = postFactory.CreateNew(Guid.NewGuid());
        blog.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }
