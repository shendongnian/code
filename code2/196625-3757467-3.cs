    public User GetUser(long uid)
    {
        User dbUser;
        using (var entities = new myEntities())
        {
            dbUser = entities.DbUsers
                      .Where( x => x.uid == uid && x.account_status == (short)AccountStatus.Active )
                     .FirstOrDefault(); // query executed against DB
        }
        return dbUser.ToUserEntity();
    }
