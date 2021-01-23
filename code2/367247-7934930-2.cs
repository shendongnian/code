    using (var context = new MyContext())
    {
        var user = new User();
        var userProfile = new User_Profile();
        
        user.user_profile = userProfile;
        context.Users.Add(user);
        context.SaveChanges();
    }
