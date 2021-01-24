    public List<Contact> GetContacts()
    {
        contactList = new List<Contact>();
        var store = new Contacts.CNContactStore();
        var ContainerId = new CNContactStore().DefaultContainerIdentifier;
        var predicate = CNContact.GetPredicateForContactsInContainer(ContainerId);
        var fetchKeys = new NSString[] { CNContactKey.Identifier, CNContactKey.GivenName, CNContactKey.FamilyName, CNContactKey.Birthday, CNContactKey.PostalAddresses, CNContactKey.ImageData };
        NSError error;
        var IPhoneContacts = store.GetUnifiedContacts(predicate, fetchKeys, out error);
        foreach(var c in IPhoneContacts)
        {
            var contact = new Contact();
            contact.FirstName = c.GivenName;
            contact.FamilyName = c.FamilyName;
            if(c.PostalAddresses.Length !=0)
            {
                contact.StreetAddress = CNPostalAddressFormatter.GetStringFrom(c.PostalAddresses[0].Value, CNPostalAddressFormatterStyle.MailingAddress);
            };
            contactList.Add(contact);
        }
        return contactList;
    }
