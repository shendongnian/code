    private List<User> FilterUsers(string username, string userid, int? minAge, int? maxAge)
    {
        IEnumerable<User> query = GetUsers();
        if (!string.IsNullOrEmpty(username)) query = query.Where(u => u.Username.StartsWith(username);
        if (!string.IsNullOrEmpty(userid)) query = query.Where(u => u.Userid == userid);
        if (minAge != null) query = query.Where(u => u.Age >= minAge.Value);
        if (maxAge != null) query = query.Where(u => u.Age <= maxAge.Value);
        return query.ToList();
    }
