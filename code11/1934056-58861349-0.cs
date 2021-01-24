    public class MyHostedService : IHostedService
    {
        private readonly IServer _server;
    
        public MyHostedService(IServer server)
        {
           _server = server;
        }
    
        public async Task StartAsync(CancellationToken cancellationToken)
        {
           var features = _server.Features;
           var addresses = features.Get<IServerAddressesFeature>();
           var address = addresses.Addresses.FirstOrDefault(); // = http://localhost:5000
        }
    }
