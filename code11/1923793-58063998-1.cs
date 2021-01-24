    public async Task<bool> SaveContact(ContactModel contactModel)
            {
                using (ContactDBContext db = new ContactDBContext())
                {
                    Contacts contact = db.Contacts.Where
                             (x => x.ContactId == contactModel.ContactId).FirstOrDefault();
                    if (contact == null)
                    {
                            contact = new Contacts()
                        {
                            ContactName = contactModel.ContactName,
                            CompanyId = contactModel.CompanyId
                    };
                        db.Contacts.Add(contact);
                        }
                    else
                    {
                        contact.ContactName = contactModel.ContactName;
                        contact.CompanyId = contactModel.CompanyId;
                    }
    
                    return await db.SaveChangesAsync() >= 1;
                }
            }
