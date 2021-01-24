    public void InsertSampleStuff()
    {
        _context.Music.AddAsync(new music("abc"));
        _context.Music.AddAsync(new music("123"));
        _context.SaveChangesAsync();
    }
