    public ActionResult Index()
    {
        var model  = new MemberShipViewModel();
        //We check here if the logged in user is already following the user being viewd
        
        foreach(var member in  Membership.GetAllUsers())
        {
          
          var user = (from a in db.FollowingUsers where a.FollowerId == User.Identity.Name && a.FollowingId == member.UserName select a).FirstOrDefault();
         model.Members.Add(new Member{UserName = member.UserName,IsFollowing=user!=null});
        }
        //This line will remove the logged in user.   
        model.Members.Remove(model.Members.First(m=>m.UserName==User.Identity.Name)); 
           
         
        return view(model);
    }
