        var userSessionList1 = userSessionList.Where(u => 
            (u.User.FirstName.ToLower().Contains(name))
        )
        .ToList();
        var userSessionList2 = userSessionList.Where(u => 
            (u.User.FirstName.ToLower().Contains(name))
        )
        .ToList();
        var userSessionListBoth = userSessionList.Where(u => 
            (u.User.FirstName.ToLower().Contains(name)) || 
            (u.User.LastName.ToLower().Contains(name))
        )
        .ToList();
