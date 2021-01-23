    public static List<ContactDetail> GetAllContact(string username, string password)
    {
        List<ContactDetail> contactDetails = new List<ContactDetail>();
        ContactsQuery query = new ContactsQuery(ContactsQuery.CreateContactsUri("default"));
        RequestSettings rs = new RequestSettings("W7CallerID", username, password);
        ContactsRequest cr = new ContactsRequest(rs);
        
        Feed<Contact> feed = cr.GetContacts();
        foreach (Contact entry in feed.Entries)
        {
            ContactDetail contact = new ContactDetail
            {
                Name = entry.Name.FullName,
                EmailAddress1 = entry.Emails.Count >= 1 ? entry.Emails[0].Address : "",
                EmailAddress2 = entry.Emails.Count >= 2 ? entry.Emails[1].Address : "",
                Phone = entry.Phonenumbers.Count >= 1 ? entry.Phonenumbers[0].Value : "",
                Details = entry.Content,
                Pic = System.Drawing.Image.FromStream(cr.Service.Query(entry.PhotoUri))
            };
            contactDetails.Add(contact);
        }
        return contactDetails;
    }
