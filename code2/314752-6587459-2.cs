    public static void LogLoginInfo(int userID)
    {
        using (var context = new MyEntities())
        {
            var user = User.GetByID(userID);
            var log = new LoginLog { Date = DateTime.Now };
            user.LoginLogs.Add(log);
            context.User.Attach(user);
            context.SaveChanges();
        }
    }
