    var postsByMonth = (from post in context.Posts
                                where post.Date >= start && post.Date < end
                                orderby post.Date descending
                                select post).GroupBy(post => new DateTime(post.Date.Year, post.Date.Month, 1));
    
                foreach (IGrouping<DateTime, Post> posts in postsByMonth)
                {
                    Console.WriteLine("{0:MMM} {0:yyyy}", posts.Key);
                    Console.WriteLine("======================");
                    Console.WriteLine();
    
                    foreach (Post post in posts)
                    {
                        Console.WriteLine("Post from {0}", post.Date);
                    }
    
                    Console.WriteLine();
                }
