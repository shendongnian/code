    public static void AddUser(string username, string password, Roles role)
    {
        // in general check if a string is empty!
        if(username.IsNullOrWhitespace())
        {
            // TODO: SHOW AN ERROR IN THE GUI THAT USERNAME MAY NOT BE EMPTY
            Debug.LogWarning("username may not be empty!", this);
            return;
        }
        if(logins.ContainsKey(username))
        {
            // TODO: SHOW AN ERROR IN THE GUI THAT THIS USER ALREADY EXISTS
            Debug.LogWarning($"A User with name \"{username}\" already exists! Please chose another username.", this);
            return;
        }
        logins.Add(username, password);
        roles.Add(role);
    }
