    public ActionMethod NewBlogPost()
    {
        BlogPost newBlogPost = new BlogPost();
        TryUpdateModel<INewBlogPost>(newBlogPost);
        if (ModelState.IsValid)
        {
            ...
        }
    }
