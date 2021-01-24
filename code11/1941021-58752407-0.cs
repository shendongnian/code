    public IEnumerable<ClientAccessory> GetClientAccessories(Guid ClientReference)
    {
        var _context = new DBContext();
    
        var results = from ca in _context.ClientAccessory.Include("Accessory")
            where ca.IsActive == true || ca.IsActive == null
            select ca;
        return results;
    }
