   var users = from user in context.Users
     select new User { 
        Name = user.Name,
        Surname = user.Surname,
        Entries = user.Entries.Where(u => u.Timestamp > X && u.Timestamp < Y).ToList()
     }
