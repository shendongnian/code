    var post = new Post()
                    {
                        Title = "TEST", 
                        Body = "Test body text"
                    };
    var comment = new Comment()
                        {
                            Author = "commentor", 
                            Text = "some comment", 
                            Url = "google.com"
                        };
                    
    post.Comments = new Collection<Comment> {comment};
    
    db.Entry(post).State = EntityState.Added;
    db.Entry(comment).State = EntityState.Added;
    db.SaveChanges();
        
