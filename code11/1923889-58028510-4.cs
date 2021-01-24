    public class HubTest: Hub {
        public async Task NewMessage(string message)
        {
            await Clients.All.newMessage(message);
        }
        public static void NewMessageToAll(string message)
        {
            GlobalHost.ConnectionManager.GetHubContext<HubTest>().Clients.All.newMessage(message);
        }
    }
