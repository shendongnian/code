    //keeping it local
    public List<User> GetUsers()
    { 
        using (var db = new GJobEntities())
            return db.Users.ToList();
    }
    
