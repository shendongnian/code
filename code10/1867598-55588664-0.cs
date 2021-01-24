    public static class PostInitializer
    {
        public static void Seed()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                if (dbContext.Database.Exists())
                {
                    if(!dbContext.Posts.Any())
                    {
                        var posts = new List<Post>
                        {
                            new Post()
                            {
                                Content = "TestA"
                            },
                            new Post()
                            {
                                 Content = "TestB"
                            }
                        };
                        posts.ForEach(p => dbContext.Posts.Add(p));
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
