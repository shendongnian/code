    var contactOption = _context.ContactOptions.FirstOrDefault(c => c.Id == someId);
    var user = _context.Users.Include("UserContacts.ContactOption")
              .Where(id => id == 1);
    var contact = new UserContact 
    { 
        ContactOptionId = contactOption.Id,  
        UserId = user.Id,
        Data = "someData"
    };
    
    user.UserContacts.Add(contact);
    context.SaveChanges();
