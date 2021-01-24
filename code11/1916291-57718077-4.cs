    public IQueryable<Row> GetAll(bool includeInactive = false)
    {
       var query = includeInactive 
          ? _context.Rows.AsQueryable()
          : _context.Rows.Where(x => x.IsActive);
       return query;
    }
