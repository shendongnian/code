    using (var db = new UserEntities())
    {
        Role roleToRemove = db.Roles.Single(SelectRoleHere);
        User user = db.Users.Single(SelectUserHere);
        user.Roles.Remove(roleToRemove);
        db.SaveChanges();
    }
