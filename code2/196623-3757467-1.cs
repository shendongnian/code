    public User GetUser(long uid)
    {
        using (var entities = new myEntities())
        {
            return entities.DbUsers
                      .Where( x => x.uid == uid && x.account_status == (short)AccountStatus.Active )
                     .FirstOrDefault()
                     .ToUserEntity();
    
        }
    }
