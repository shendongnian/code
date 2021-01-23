    public ActionResult AddComment(PostComment postComment)
    {
        postComment.PostedDate = DateTime.Now;
        postCommentRepo.AddPostComment(postComment);
        postCommentRepo.SaveChanges();
        if (Request.IsAjaxRequest())
            return PartialViewFor(postComment);
        else
            return RedirectToAction("BlogPost", new { Id = postComment.BlogPostID });
    }
