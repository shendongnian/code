    [HttpGet]
    public ActionResult Info(int id)
    {
        User user = db.Users.FirstOrDefault(u => u.Id == id);    
        // populate ListMessage
        user.ListMessage = new List<string> { user.Message };
        // return User model to view    
        return View(user);
    }
