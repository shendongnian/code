    public void UpdateUser(int userId, Action<User> callback)
    {
        using (var db = new DataContext())
        {
            User entity = db.Users.Where(u => u.Id == userId).Single();
    
            callback(entity);
            db.SubmitChanges();
        }
    }
    myrepository.UpdateUser(userId, user =>
    {
        user.Username = username;
        user.Password = password;
        // etc...
    });
