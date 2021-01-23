    public class Ping : IRequest<Pong>
    {
        public string Message { get; set; }
    }
    public class Pong
    {
        public string Message { get; set; }
    }
    public class PingAsync : IAsyncRequest<Pong>
    {
        public string Message { get; set; }
    }
    public class Pinged : INotification { }
    public class PingedAsync : IAsyncNotification { }
