    [EnableQuery]
    public SingleResult<User> Get(long key)
    {
        var query = _context.Users.Where(p => p.Id == key);
        return SingleResult.Create(query);
    }
