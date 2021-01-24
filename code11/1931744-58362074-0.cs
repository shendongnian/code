    [HttpGet("[action]")]
    public IEnumerable<Client> GetClients(int fromId, int toId)
    {
        return _context.Client.Where(c => c.Id <= toId && c.Id >= fromId).Take(100).AsEnumerable();
    }
