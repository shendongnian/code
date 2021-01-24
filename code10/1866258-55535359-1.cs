    ......
    
    _context.Users.Add(user);
    
    SecondTable secondTable = new SecondTable();
    secondTable.UserId = user.Id; // <-- Just point the user Id here
    _context.SecondTables.Add(secondTable);
    
    _context.SaveChanges();
