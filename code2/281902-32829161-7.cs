    [Then(@"a post in the ""(.*)"" Blog should exist with the following attributes:")]
    public void ThenAPostInTheBlogShouldExistWithTheFollowingAttributes(string blogName, Table table)
    {
        using (IDbContext ctx = new TestContext())
        {
            Blog blog = ctx.Blogs.Where(b => b.Name == blogName).Single();
            
            foreach (BlogPost post in blog.Posts)
            {
                BlogPostRow actual = new BlogPostRow(post);
                table.CompareToInstance<BlogPostRow>(actual);
            }
        }
    }
