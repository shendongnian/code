    interface INotificationService : { }
    class TwitterNotificationService : INotificationService { }
    class FacebookNotificationService : INotificationService { }
    class CompositeNotificationService : INotificationService
    {
        public CompositeNotificationService(IEnumerable<NotificationService> services) { }
    }
    
    class NotificationController : Controller
    {
        public NotificationController(INotificationService service) { }
    }
