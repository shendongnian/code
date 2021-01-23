    public bool check_username(ArrayList userList, string username)
    { 
        return userList.Cast<string>()
               .Any(s => s.Equals(username, StringComparison.OrdinalIgnoreCase); 
    } 
