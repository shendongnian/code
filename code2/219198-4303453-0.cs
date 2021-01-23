    public object GetDTO()
    {
         object data = new
         {
             pageData = new
             {
                Id = Post.Id,
                pageUrl = Post.URL,
                title = Post.PageTitle,
                description = Post.PageDescription,
                user = Post.User.Name
            }
        };
        return data;
    }
