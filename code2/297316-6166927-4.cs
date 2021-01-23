    interface INotificationService { }
    class TwitterNotificationService : INotificationService { }
    class FacebookNotificationService : INotificationService { }
    class CompositeNotificationService : INotificationService
    {
        public CompositeNotificationService(IEnumerable<NotificationService> services) { }
        // implement composite pattern
    }
    
    class NotificationController : Controller
    {
        public NotificationController(INotificationService service)
        {
            if (service === null)
            {
                throw new ArgumentNullException("service");
            }
            // ...
        }
    }
