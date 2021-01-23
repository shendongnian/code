    public bool UpdateUser(User user)
    {
        context.AttachTo("Users", user);
        context.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
        return context.SaveChanges() > 0;
    }
