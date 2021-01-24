    [HubName("NotificationHub")]
    public class NotificationHub: Hub
        {
            public Task SendMessage(string user, string message)
            {
                return Clients.All.SendAsync("ReceiveMessage", user, message);
            }
        }
