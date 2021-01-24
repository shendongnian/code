    [HttpGet]
    public ActionResult Info(int id)
    {
        // get user with user.Id == id
        User user = db.Users.FirstOrDefault(u => u.Id == id);
        
        if (user == null)
        {
            // handle null
        }
        
        // populate listmessage
        user.ListMessage = new List<string> { user.Message };
        // send a List<string> to view
        return View(user.ListMessage);
    }
