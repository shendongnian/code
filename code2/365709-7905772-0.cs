    public TUser GetUser<TUser>(string userName) where TUser : IUser
    {
        return Warehouse.GetRepository<TUser>().GetAll()
            .First(u => u.Name == userName);
    }
