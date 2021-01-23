    public IQueryable<Contact> GetContacts(dbDataContext db, string clientID)
    {
        return from _contacts in db.Contacts
               where _contacts.ClientID == clientID
               orderby _contacts.LastName ascending
               select _contacts;
    }
