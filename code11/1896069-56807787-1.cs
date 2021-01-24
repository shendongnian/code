    public void InsertSampleStuff() {
        _context.Music.Add(new music("abc"));
        _context.Music.Add(new music("123"));
        _context.SaveChanges();
    }
