    Contacts contact = db.Contacts.Where(x => x.ContactId == contactModel.ContactId).FirstOrDefault();
    
    Company company = db.Companies.Where(x => x.ContactId == contactModel.ContactId).FirstOrDefault();
    
     contact.ContactName = contactModel.ContactName;
     contact.Company.CompanyName = contactModel.Company.CompanyName;
