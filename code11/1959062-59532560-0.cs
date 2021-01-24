    public void ChangeRoleFromUserToSubscribedUser(User u)
    {
        var role = u.Roles.FirstOrDefault();
        role.Title = "Subscribed User";
        Entity.Entry(entity).State = EntityState.Modified;
    
        Entity.SaveChanges();
    }
