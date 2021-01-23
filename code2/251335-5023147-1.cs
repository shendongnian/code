    [HttpPost]
    public ViewResult EditBlogPost(int postID)
    {
        var post = db.BlogPosts.Single(p => p.PostID = postID);
        TryUpdateModel(post);
        if (!ModelState.IsValid)
            return View("ManageBlogPost");
        db.SaveChanges();
        ViewData["message"] = "Blog post edited successfully.";
        return View("Result");
    }
