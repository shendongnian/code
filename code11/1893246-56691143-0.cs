    public class NotificationHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    }
