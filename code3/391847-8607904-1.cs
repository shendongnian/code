    var loadOptions = new DataLoadOptions();
    loadOptions.LoadWith<Post>(p => p.Comments);
    blogDataContext.LoadOptions = loadOptions;
    
    // SELECT * FROM Posts JOIN Comments ...
    var postsQuery = (from post in blogDataContext.Posts
                     select post);
    
    foreach (Post post in postsQuery)
    {   
        // no lazy loading of comments list causes    
        foreach (Comment comment in post.Comments)
        {       
            //print comment...   
        }
    }
