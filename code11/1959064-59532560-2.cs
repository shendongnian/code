    public void ChangeRoleFromUserToSubscribedUser(User u)
    {
        var role = u.Roles.FirstOrDefault();
        role.Title = "Subscribed User";
        Entity.Entry(role).State = EntityState.Modified;
    
        Entity.SaveChanges();
    }
