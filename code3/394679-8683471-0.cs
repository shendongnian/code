    public Expression<Func<Customer, bool>> GetDave()
    {
        return c => c.FirstName == "Dave"
                 && c.IsActive
                 && c.HasAddress;
    }
