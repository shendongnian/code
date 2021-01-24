    public IEnumerable<EmailAddress> GetAddressesByPerson(int personId)
    {
        var queryResults = Context.Persons
            .Where(x => x.Id == personId)
            .Select(x => new { EmailAddresses = x.EmailAddresses })
            .Single(); 
    
        return queryResults.EmailAddresses;
    }
