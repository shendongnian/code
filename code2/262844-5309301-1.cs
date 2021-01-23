    public ActionResult Index()
    {
        var currentUser = Membership.GetUser();
        var userId = (Guid)currentUser.ProviderUserKey;
        var users = 
            from m in db.Users
            join m2 in db.MyProfiles on m.UserId equals m2.UserId
            where m.UserId == userId
            select new UserViewModel
            {
                UserName = m.UserName, 
                LastActivityDate = m.LastActivityDate,
                Address =  m2.Address, 
                City = m2.City, 
                State = m2.State, 
                Zip = m2.Zip
            };
        return View(users);
    }
