    public Task GetAllUsers()
    {
        // Get the ConnectionId
        var connectionId = Context.ConnectionId;
        // Get the users list
        var users = userRepository.GetAllUsers(); 
        // ...
        return Clients.User(user).SendAsync("UserListRequested", users);
    }
