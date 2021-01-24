    public class HubBase : Hub
    {
        public readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();
        public override async Task OnConnected()
        {
            var group = Context.QueryString["group"];
            //I tried to add the user to the given group using one of the following method
            await Groups.Add(Context.ConnectionId, group); 
            await AddToGroup(Context.ConnectionId, group);
            //other stuff
        }
    }
