    public void ChangeUserName(int userId, string name)
    {
        Require.ThatArgument(userId > 0);
        Require.ThatArgument(!string.IsNullOrWhitespace(name,
            () => "Usernames must be non-empty strings");
        var user = GetUser(userId);
        Require.That(user != null, 
            () => new UserDoesNotExistException("No user exists with ID " + userId));
        user.Name = name;
        ...
    }
