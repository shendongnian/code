    public class PingHandler : IRequestHandler<Ping, Pong> { /* Impl */ }
    public class PingAsyncHandler : IAsyncRequestHandler<PingAsync, Pong> { /* Impl */ }
    
    public class PingedHandler : INotificationHandler<Pinged> { /* Impl */ }
    public class PingedAlsoHandler : INotificationHandler<Pinged> { /* Impl */ }
    public class GenericHandler : INotificationHandler<INotification> { /* Impl */ }
    
    public class PingedAsyncHandler : IAsyncNotificationHandler<PingedAsync> { /* Impl */ }
    public class PingedAlsoAsyncHandler : IAsyncNotificationHandler<PingedAsync> { /* Impl */ }
