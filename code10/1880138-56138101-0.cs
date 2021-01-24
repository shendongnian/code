    // Create your client
    GraphServiceClient graphClient =
        new GraphServiceClient("https://graph.microsoft.com/v1.0",
            new DelegateAuthenticationProvider(async(requestMessage) =>
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("bearer", await GetTokenAsync(iclientApp));
            })
        );
    
    // Get your list of users
    string filter = String.Format("startswith(surname,'{0}')", "ADTest");
    var users = await graphClient.Users
        .Request()
        .Filter(filter)
        .GetAsync();
    
    // Grab the first user returned to use as the manager
    var manager = users[0];
    
    // Assign this manager to the user currently signed in
    await graphClient.Me.Manager.Reference.Request().PutAsync(manager.Id);
