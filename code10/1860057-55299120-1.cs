    [HubName("yourHub")]
    public class MyHub : Hub
    {
        public override Task OnConnected()
        {
            var userEmail = Context.QueryString["useremail"]?.ToLower();
            if (userEmail == null) throw new Exception("Unable to Connect to Signalr hub");
            if (NotificationsResourceHandler.Groups.All(x => x.Value != userEmail))
            {
                NotificationsResourceHandler.Groups.Add(Context.ConnectionId, userEmail);
                Groups.Add(Context.ConnectionId, userEmail);
            }
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            NotificationsResourceHandler.Groups.Remove(Context.ConnectionId);
            Clients.All.removeConnection(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
