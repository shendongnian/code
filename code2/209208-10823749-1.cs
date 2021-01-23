    context.Users.Add(User.Create(c=>
    {
        c.Name = "User";
        c.Email = "some@one.com";
        c.Salt = salt;
        c.Password = "mypass";
        c.Roles = new List<Role> { adminRole, userRole };
    }));
