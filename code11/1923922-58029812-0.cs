    var blogs = new List<Blogs>();
    var posts = new List<Posts>();
    using (var context = new BloggingContext())
    {
        blogs = context.Blogs.Include(blog => blog.Posts).ToList();
    }
    foreach(var p in blogs.Posts)
    {
      posts.add(p);
    }
