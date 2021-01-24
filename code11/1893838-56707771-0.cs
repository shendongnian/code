    private async Task<List<User>> GetUsersFromGraph()
    {
        if (_graphAPIConnectionDetails == null) ReadParametersFromXML();
        if (graphServiceClient == null) graphServiceClient = CreateGraphServiceClient();
    
        // Create a bucket to hold the users
        List<User> users = new List<User>();
    
        // Get the first page
        IGraphServiceUsersCollectionPage usersPage = await graphClient
            .Users
            .Request()
            .Filter("filter string")
            .Select("property string")
            .GetAsync();
    
        // Add the first page of results to the user list
        users.AddRange(usersPage.CurrentPage);
    
        // Fetch each page and add those results to the list
        while (usersPage.NextPageRequest != null)
        {
            usersPage = await usersPage.NextPageRequest.GetAsync();
            users.AddRange(usersPage.CurrentPage);
        }
    
        return users;
    }
