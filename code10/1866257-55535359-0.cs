    ......
    
    _context.Users.Add(user);
    
    SecondTable secondTable = new SecondTable();
    secondTable.UserId = user.Id; // <-- Here you can set it
    _context.SecondTables.Add(secondTable);
    
    _context.SaveChanges();
