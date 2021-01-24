    public async Task Add<T>(string url)
    {
        using (var context = new BloggingContext())
        {
            var blog = new Blog { Url = url };
            await Task.RunTask.Run( () =>
            {
                context.Blogs.Add(blog);
            }); 
        }
    }
