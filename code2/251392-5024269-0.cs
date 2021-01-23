    var queryResult = (from post in context.Posts
                    select new
                               {
                                   post,
                                   post.Author,
                                   post.Tags,
                                   post.Categories,
                                   Count = context.Comments.Where(c => c.Post == post).Where(c => IsPublic == 1).Count()
                               }).ToList();
