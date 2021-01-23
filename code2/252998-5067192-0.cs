    public ActionResult Profile()
    {
        //Based on business logic, set variables 
        if(userProfile)
        {
            return View("Profile");
        }
        else if(friendProfile)
        {
            return View("FriendProfile");
        }
    }
