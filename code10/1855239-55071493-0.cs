    [Authorize]
    public ActionResult AddComment(RestaurantViewModel model, Comment newComment)
    {
        var userId = User.Identity.GetUserId();
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
    
        newComment.RestaurantId = model.Restaurant.Id;
        newComment.AuthorId = Guid.Parse(userId);
        newComment.AuthorName = user.UserName;
        newComment.DateTime = DateTime.Now;
    
        _context.Comments.Add(newComment);
        _context.SaveChanges();
    
        return RedirectToAction("Details", "Restaurants", new { id = model.Restaurant.Id});
    }
