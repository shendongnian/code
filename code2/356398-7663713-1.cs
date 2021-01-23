    using (var context = new MyContext())
    {
        var userType = context.UserTypes
            .Single(u => u.Type == TypeEnum.Admin.ToString());
        var newUser = new User { TypeId = userType, Username = ... etc. };
        context.Users.Add(newUser);
        context.SaveChanges();
    }
