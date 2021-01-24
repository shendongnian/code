    `var UserWithoutPassword = users.USERs.Select()
               .Where(u => u.USERNAME == username).Select(x => new
                               {
                                    P1 = table.Prop1,
                                    P2 = table.Prop2
                               }).ToList();
    Content = new StringContent(users.USERs.Where(u => u.USERNAME == username).ToList()`
