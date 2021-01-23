    public static User GetByID(int userID)
    {
        using (var context = new MyEntities())
        {
           return context.Users.Include("LoginLogs").Where(qq => qq.UserID == userID).FirstOrDefault();
        }
    }
 
