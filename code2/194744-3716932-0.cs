    public IQueryable<Contact> GetContacts(string clientID)
    {
        IQueryable contacts;
        using (dbDataContext db = new dbDataContext())
        {
            contacts = from _contacts in db.Contacts
                            where _contacts.ClientID == clientID
                            orderby _contacts.LastName ascending
                            select _contacts;
    
            
        }
    
        return contacts;
    }
