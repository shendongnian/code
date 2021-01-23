    var queryResult = (from post in posts
                        select new
                                   {
                                       post,
                                       post.Author,
                                       post.Tags,
                                       post.Categories,
                                       Count = post.Comments.Cast<Comment>()
                                                            .Where(x=>x.IsPublic).Count()
                                   }).ToList();
