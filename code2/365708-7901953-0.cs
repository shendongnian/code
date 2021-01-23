    public IUser GetUser(string userName)
    {
        return Warehouse.GetRepository<IUser>().GetAll()
            .AsEnumerable()
            .First(u => u.Name == userName);
    }
