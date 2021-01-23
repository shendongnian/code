    public User GetUser(long uid)
    {
        using (var entities = new myEntities())
        {
            short status = (short)AccountStatus.Active;
            return GetUser(
                entities.DbUsers
                    .Where( x => x.uid == uid && x.account_status == status )
                    .FirstOrDefault(),
                uid);
        }
    }
