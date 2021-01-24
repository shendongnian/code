    private void SortContacts()
    {
    	// order by name
        var sortedContact = ContactList.OrderBy(x => x.Name).ToList();
    
        for (int i = 0; i < sortedContact.Count(); i++)
            ContactList.Move(ContactList.IndexOf(sortedContact[i]), i);
    }
