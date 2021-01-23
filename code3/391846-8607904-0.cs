        // SELECT * FROM Posts
    var postsQuery = from post in blogDataContext.Posts
                     select post;
    
    foreach (Post post in postsQuery)
    {   
        //lazy loading of comments list causes:    
        // SELECT * FROM Comments where PostId = @p0   
        foreach (Comment comment in post.Comments)
        {       
            //print comment...   
        }
    }
