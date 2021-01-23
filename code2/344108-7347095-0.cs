    public void SaveUser (User user) {
        var userToUpdate = context.Users.Where(u => u.Id == user.Id).Single();
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        
        context.SubmitChanges();
    }
