    public List<ContactModel> ReadContacts()
    {
        var response = new List<ContactModel>();
        try
        {
            //We can specify the properties that we need to fetch from contacts  
            var keysToFetch = new[] {
        CNContactKey.PhoneNumbers, CNContactKey.GivenName, CNContactKey.FamilyName
    };
            //Get the collections of containers  
            var containerId = new CNContactStore().DefaultContainerIdentifier;
            //Fetch the contacts from containers  
            using (var predicate = CNContact.GetPredicateForContactsInContainer(containerId))
            {
                CNContact[] contactList;
                using (var store = new CNContactStore())
                {
                    contactList = store.GetUnifiedContacts(predicate, keysToFetch, out
                        var error);
                }
                //Assign the contact details to our view model objects  
                response.AddRange(from item in contactList
                                    where item?.EmailAddresses != null
                                    select new ContactModel
                                    {
                                        PhoneNumbers = item.PhoneNumbers,
                                        GivenName = item.GivenName,
                                        FamilyName = item.FamilyName
                                    });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return response;
    }
