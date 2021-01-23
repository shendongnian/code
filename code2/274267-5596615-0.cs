    public IEnumerable<Result> Search(string searchText)
    {
        if(string.IsNullOrEmpty(searchText))
            return _context.Person;
        else
            return _context.Person.Where(x => x.Contains(searchText));
    }
