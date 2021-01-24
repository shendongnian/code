    public async Task<IEnumerable<Contacts>> GetAll()
    {
        var models = await _context
            .Contacts
            .Select(contact => new
            {
                contact.date_released,
                contact.utoken,
                contact.Images,
                contact.images_key,
                contact.Type        
            })
            .ToListAsync()
        
        return models
            .Select(item => new ValidationModel
            {
                uToken = item.utoken,
                Date = item.date_released,
                Images = bc.Decrypt(item.Images, item.images_key),
                Type = item.Type
            }
            .ToList();   
    }
