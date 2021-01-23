    public List<ContactDetails> GetAllContactDetails( List<Guid> ContactIDs, Func<List<ContactDetails>, IEnumerable<ContactDetails>> filter )
    {
    	List<ContactDetails> result = new List<ContactDetails>();
    
    	// get contacts as usual, fill result
    	// ...
    
    	return filter.Invoke( result ).ToList();
    }
