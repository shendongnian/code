    [HttpPost]
    public ViewResult EditBlogPost(int postID, FormCollection collection)
    {
        if (!ModelState.IsValid)
            return View("ManageBlogPost");
        var post = db.BlogPosts.Single(p => p.PostID = postID);
        UpdateModel(post);
        db.SaveChanges();
        ViewData["message"] = "Blog post edited successfully.";
        return View("Result");
    }
