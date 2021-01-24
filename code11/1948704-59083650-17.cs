    public async Task Add<T>(string url)
    {
        using (var context = new BloggingContext())
        {
            var blog = new Blog { Url = url };
            context.Blogs.Add(blog);
            await context.SaveChangesAsync();
        }
    }
