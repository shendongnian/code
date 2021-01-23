    if(ModelState.IsValid)
    {
     // Insert new comment
     ..
     ..
     // Redirect to a different view
    }
    // Something is wrong, return to the same view with the model & errors 
    var postModel = new BlogPostViewModel { PostComment = postComment };
    return View(postModel);
