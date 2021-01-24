    public class UptimeHub : Hub
    {
    }
    public class BackgroundUptimeServerTimer : IRegisteredObject
    {
        private readonly DateTime _internetBirthDate = On.October.The29th.In(1969);
        private readonly IHubContext _uptimeHub;
        private Timer _timer;
     
     
        public BackgroundUptimeServerTimer()
        {
            _uptimeHub = GlobalHost.ConnectionManager.GetHubContext<UptimeHub>();
     
            StartTimer();
        }
        private void StartTimer()
        {
            var delayStartby = 2.Seconds();
            var repeatEvery = 1.Seconds();
     
            _timer = new Timer(BroadcastUptimeToClients, null, delayStartby, repeatEvery);
        }
        private void BroadcastUptimeToClients(object state)
        {
            TimeSpan uptime = DateTime.Now - _internetBirthDate;
     
            _uptimeHub.Clients.All.internetUpTime(uptime.Humanize(5));
        }
         
        public void Stop(bool immediate)
        {
            _timer.Dispose();
     
            HostingEnvironment.UnregisterObject(this);
        }
    }
