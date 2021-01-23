    // POST: /posts/comment
    [HttpPost, Authorize]
    public ActionResult Comment(CommentViewModel newComment)
    {
        if (!ModelState.IsValid)
        {
            TempData.Add(commentFormModelStateKey, ModelState);
            return Redirect(Url.ShowPost(newComment.PostID, newComment.Slug));
        }
        // Code to add a comment goes here.
    }
