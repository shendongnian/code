    var posts = new List<Posts>();
    using (var context = new BloggingContext())
    {
        var blogs = context.Blogs.Include(blog => blog.Posts).ToList();
        foreach(var p in blogs.Posts)
        {
           posts.add(p);
        }
    }
