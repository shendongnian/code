    using (MovieAppContext _context = new MovieAppContext())
    {
        bool queryResult = _context.Set<T>().Any((e) => e.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase));
        if (queryResult)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
    }
