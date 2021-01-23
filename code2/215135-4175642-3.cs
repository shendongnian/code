    var contactOption = _context.ContactOptions.Find(someId);
    var user = _context.Users.Find(1);
    var contact = new UserContact 
    { 
        ContactOptionId = contactOption.Id,  
        UserId = user.Id,
        Data = "someData"
    };
    
    user.UserContacts.Add(contact);
    context.SaveChanges();
