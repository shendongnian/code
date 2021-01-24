    // Injected services:
    //private readonly IUserSession _userSession;
    //private readonly IClientStore _clientStore;
    //private readonly IBackChannelLogoutService _backChannelClient;
    private async Task LogoutUserAsync(string logoutId)
    {
        if (User?.Identity.IsAuthenticated == true)
        {
            // delete local authentication cookie
            await HttpContext.SignOutAsync();
            // Get all clients from the user's session
            var clientIds = await _userSession.GetClientListAsync();
            if (clientIds.Any())
            {
                var backChannelClients = new List<BackChannelLogoutModel>();
                var sessionId = await _userSession.GetSessionIdAsync();
                var sub = User.Identity.GetSubjectId();
                foreach (var clientId in clientIds)
                {
                    var client = await _clientStore.FindEnabledClientByIdAsync(clientId);
                    // This should be valid in any case:
                    if (client == null && !string.IsNullOrEmpty(client.BackChannelLogoutUri))
                        continue;
                    // Insert here the logic to retrieve the tenant url for this client
                    // and replace the uri:
                    var tenantLogoutUri = client.BackChannelLogoutUri;
                    backChannelClients.Add(new BackChannelLogoutModel
                    {
                        ClientId = client.ClientId,
                        LogoutUri = tenantLogoutUri,
                        SubjectId = sub,
                        SessionId = sessionId,
                        SessionIdRequired = true
                    });
                }
                try
                {
                    await _backChannelClient.SendLogoutNotificationsAsync(backChannelClients);
                }
                catch (Exception ex)
                {
                    // Log message
                }
            }
            // raise the logout event
            await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
        }
    }
