            var queryResult = (from post in posts
                               join comment in comments.Where(x=> x.IsPublic) on post.Id equals comment.Post.Id into g
                        select new
                                   {
                                       post,
                                       post.Author,
                                       post.Tags,
                                       post.Categories,
                                       Count = g.Count()
                                   })
