    public class ConnectionCounters
    {
        private Dictionary<string, ConnectionCounter> _counters = new Dictionary<string, ConnectionCounter>();
        public IEnumerable<ConnectionCounter> GetCounters()
        {
            return _counters.Values;
        }
        public void Handle(ConnectionEvent @event)
        {
            var counter = GetOrCreateCounter(@event.Destination);
            if (@event is ConnectEvent)
                counter.ConnectionCount += 1;
            if (@event is DisconnectEvent)
                counter.ConnectionCount -= 1;
        }
        private ConnectionCounter GetOrCreateCounter(string destination)
        {
            if (_counters.ContainsKey(destination))
                return _counters[destination];
            
            var counter = new ConnectionCounter() { Destination = destination };
            _counters[destination] = counter;
            return counter;
        }
    }
    public class ConnectionCounter
    {
        public string Destination { get; set; }
        public int ConnectionCount { get; set; }
    }
    public class ConnectEvent : ConnectionEvent { }
    public class DisconnectEvent : ConnectionEvent { }
    public class ConnectionEvent 
    {
        public string Destination { get; set; }
    }
    // .....
    private ConnectionCounters _connectionCounters = new ConnectionCounters();
    public void Main()
    {
        var events = ReadEvents(); // read events somehow
        foreach (var @event in events)
        {
            _connectionCounters.Handle(@event);
        }
        foreach (var counter in _connectionCounters.GetCounters())
            Console.WriteLine($"{counter.Destination} has {counter.ConnectionCount} connections.")
    }
