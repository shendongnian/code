    var contactsMatching= (from c in dbContext.Contacts 
                     join ac in dbContext.AssignedContacts on 
                     c.ID equlas ac.ContactID
                     where ac.ReferenceCaseID==<your provided id>
                      select Contact{
                         ID = c.ID,
                         FirstName= c.FirstName,
                         ..snip..
                     }).ToList();
