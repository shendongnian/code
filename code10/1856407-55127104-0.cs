    public void AddPost()
    {
        Post newPost = new Post()
        {
            postTitle = inputTitle.Text,
            postBody = inputBody.Text,
            postDescription = inputDescription.Text,
            postCategory = inputCategory.SelectedValue,
            postAnonymous = Convert.ToBoolean(Int32.Parse(inputAnonymous.SelectedValue)),
        };
    
        using (var _dbContext = new ApplicationDbContext())
        {
            _dbContext.Posts.Add(newPost);
            _dbContext.SaveChanges();
        }
    }
