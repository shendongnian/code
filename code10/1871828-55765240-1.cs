    // this has to be a task, otherwise the framework
    // cannot know when it has finished 
    public async Task NewUser(string username, string userIdentifier)
    {
        using (var dbContext = new GameContext())
        {
            string connectionID = Context.ConnectionId;
    
            bool error = false;
            bool usernameExists = false;
            bool createdUser = false;
    
            try
            {
                usernameExists  = await dbContext.Users.AnyAsync(x=> x.Username == username);
            }
            catch (Exception e)
            {
                error = true;
            }
            if (!usernameExists && !error)
            {
                Users user = new Users { Username = username, UserIdentifier = userIdentifier, Joined = DateTime.UtcNow };
                try
                {
                    dbContext.Add(user);
                    await dbContext.SaveChangesAsync();
                    createdUser = true;
                }
                catch (Exception e)
                {
                    error = true;
                }
            }
            await _hubContext.Clients.Client(connectionID).SendAsync("CreatedUser", username, usernameExists, createdUser, error);
        }
    }
