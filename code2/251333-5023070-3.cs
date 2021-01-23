    [HttpPost]
    public ViewResult EditBlogPost(BlogPost blogPost)
    {
        //This one is where I'm having issues. When model binding populates blogPost, is it auto-tracking still? For some reason SaveChanges() doesn't seem to persist the updates.
        if (!ModelState.IsValid)
            return View("ManageBlogPost");
        var dbPost = db.BlogPosts.Single(bp => bp.BlogPostId = blogPost.Id);
        UpdateModel(dbPost, "blogPost");
        db.SaveChanges();
        ViewData["message"] = "Blog post edited successfully.";
        return View("Result");
    }
