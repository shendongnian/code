    public static void LogLoginInfo(int userID)
    {
        using (var context = new MyEntities())
        {
            var user = context.User.Where(p=>p.UserID == userID); //<= The Context now knows about the User, and can track changes.
            var log = new LoginLog { Date = DateTime.Now };
            user.LoginLogs.Add(log);
            context.SaveChanges();
        }
    }
