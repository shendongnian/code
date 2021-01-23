    [When(@"I create a post in the ""(.*)"" Blog with the following attributes:")]
    public void WhenICreateAPostInTheBlogWithTheFollowingAttributes(string blogName, Table table)
    {
        using (IDbContext ctx = new TestContext())
        {
            BlogPostRow row = table.CreateInstance<BlogPostRow>();
            BlogPost post = row.CreateInstance(blogName, ctx);
            ctx.BlogPosts.Add(post);
            ctx.SaveChanges();
        }
    }
