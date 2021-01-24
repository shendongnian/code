    _context.Users.Add(user);
    _context.SaveChanges(); //add this code
    SecondTable secondTable = new SecondTable();
    secondTable.UserId = user.Id;  
    _context.SecondTables.Add(secondTable);
    _context.SaveChanges();
