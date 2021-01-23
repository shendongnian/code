    public IEnumerable<Cage> GetAll()
    {
        var dc = new DataContext();
        return dc.GetAll().ToList();
    }
