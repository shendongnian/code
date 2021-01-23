    var contacts = entities.Contacts;
    
    if (customerId != null)
    {
       contacts = contacts.Where(c => c.Individuals.Any(i => i.CustomerID == customerId.Value));
    }
    
    return contacts
        .OrderBy(o => o.LastName)
        .Take(10)
        .ToList(); 
