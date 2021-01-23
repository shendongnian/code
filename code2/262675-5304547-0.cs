    string GetUserPlaceById(int userId)
    {
        IQueryable<User> users = GetUsers(); // Get users queryable reference
        
        return users.Single(user => user.Id == userId).Place;
    }
