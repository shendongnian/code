    public User GetById(int id)
    {
       return _context.Users
                 .Include(item => item.Connections)
                 .Find(id);
    }
