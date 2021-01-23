    int id = 0;
    using (PC2Entities objectContext = new PC2Entities())
    {
       objectContext.ClientContacts.AddObject(clientContact);
       objectContext.SaveChanges();
       id = clientContact.Id;
       transaction.Complete();
    }
