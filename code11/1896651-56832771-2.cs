       public class ChatHub : Hub
        {
            public void Send(string name, string message)
            {
                // Call the broadcastMessage method to update clients.
                Clients.All.broadcastMessage(name, message);
            }
        }
    	
    	public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                // Any connection or hub wire up and configuration should go here
                app.MapSignalR();
            }
        }
