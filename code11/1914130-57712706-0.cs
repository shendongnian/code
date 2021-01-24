    var existingBlog = ... // get existing blog somehow
    List<Post> newPosts = ... // get new posts somehow
    using (var context = new BloggingContext())
    {
        context.Entry(existingBlog).State = EntityState.Modified;
        existingBlog.Posts.AddRange(newPosts);
        context.SaveChanges();
    }
