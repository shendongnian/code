    [Given(@"a Blog named ""(.*)"" exists")]
    public void GivenABlogNamedExists(string blogName)
    {
        using (IDbContext ctx = new TestContext())
        {
            Blog blog = new Blog()
            {
                Name = blogName
            };
            ctx.Blogs.Add(blog);
            ctx.SaveChanges();
        }
    }
