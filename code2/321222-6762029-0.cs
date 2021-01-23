    using (TestEntities entities = new TestEntities())
    {
      //get these from the db so we get change tracking and what not
      User userFromDb = entities.User.Where(u => u.Id == user.Id).Single();
      Roles newRoleForUser = entities.Roles.Where(r => r.Id == role.Id).Single();
      //which basically changes the role so it'll change the role property inside the user, do whatever manipulation you want, we have change tracking in place.
      userFromDb.ChangeRole(newRoleForUser);
      entities.SaveChanges();
    }
