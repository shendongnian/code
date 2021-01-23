    using(MyEntitiesContext context = new MyEntitiesContext())
    {
        var idleUsers = from u in context.User
                        where u.LoggedIn && u.LastActivity > DateTime.Now.AddMinutes(-30)
                        select u;
        
        foreach(User u in idleUsers)
        {
            u.Status = UserStatus.Idle;
        }
        context.SaveChanges();
    }
