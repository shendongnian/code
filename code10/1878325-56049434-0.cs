    public async Task<List<Person>> GetPersonsAsync()
    {
        return await _context.Person
            .Include(p => p.Tickets)
            .ToListAsync();
    }
