    async Task SetUserDetails(User user)
    {
        user.Details = await FetchUserDetails(user);
    }
    async Task UpdateUsers(IEnumerable<User> users)
    {
        var tasks = new List<Task>();
        foreach(var user in users)
        {
             tasks.Add(SetUserDetails(user));
        }
        await Task.WhenAll(tasks);
    }
