    public override async Task OnDisconnectedAsync(Exception exception) {
        var session = (VBLightSession)Context.Items["Session"];
        activeUsers.Remove(session.User.Id);
        // Prevents our application waiting to the delay if it's closed (especially during development this avoids additionally waiting time, since the clients disconnects there)
        if (!appLifetime.ApplicationStopping.IsCancellationRequested) {
            // Avoids flickering when the user switches to another page, that would cause a directly re-connect after he has disconnected. If he's still away after 5s, he closed the tab
            await Task.Delay(5000);
            if (!activeUsers.Any(u => u.Key == session.User.Id)) {
                await Clients.All.SendAsync("UserOffline", UserOnlineStateDto(session));
            }
        }
        await base.OnDisconnectedAsync(exception);
    }
