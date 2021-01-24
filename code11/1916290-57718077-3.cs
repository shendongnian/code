    public IQueryable<Row> GetAll()
    {
       var query = _context.Rows.AsQueryable();
       return query;
    }
