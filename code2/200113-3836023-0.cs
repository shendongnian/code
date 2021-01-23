    public IQueryable<IUser> FooMethod<T>(int type) where T : IUser, new()
    {
        using (MyEntities context = new MyEntities())
        {
            var results = from u in context.users
                          where u.usertype == type
                          select new T
                          {
                              id = u.UserId,
                              name = u.UserName,
                              location = u.Userlocation
                          };
            return results; 
        }
    }
