       userSessionList = userSessionList.Where(u => 
            (u.User != null && u.User.FirstName != null && u.User.FirstName.ToLower().Contains(name)) || 
            (u.User != null && u.User.LastName != null && u.User.LastName.ToLower().Contains(name))
        )
        .ToList();
