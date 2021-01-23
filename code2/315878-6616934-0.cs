    public Program GetById(int id)
    {
        var entity = _context.Programs
            .Include(p => p.Sessions.Select(s => s.Trackings))
            .Single(p => p.ID == id);
         return entity;
    }
