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
                        Company = contactModel.Company
                    };
                    db.Contacts.Add(contact);
        
                }
                else
                {
                    contact.ContactName = contactModel.ContactName;
                    contact.Company.CompanyId = contactModel.Company.CompanyId;
                }
        
                return await db.SaveChangesAsync() >= 1;
            }
        }
