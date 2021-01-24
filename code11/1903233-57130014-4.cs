    public async Task<IEnumerable<Production>> GetProductions() {
        var productions = await _context.Productions
            .Include(p => p.AuditionTimes)
            .Include(p => p.Participants)
                .ThenInclude(p => p.EmergencyContacts)
            .ToListAsync();
        return productions;
    }
