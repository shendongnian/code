    var existingBlog = ... // get existing blog somehow
    using (var context = new BloggingContext())
    {
        var newPost = new Post { Title = "some title", BlogId = existingBlog.Id };
        context.Add(newPost);
        context.SaveChanges();
    }
