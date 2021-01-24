    [HttpGet]
    public ActionResult Info(int id)
    {
        User user = db.Users.FirstOrDefault(u => u.Id == id);    
        // return User model to view    
        return View(user);
    }
