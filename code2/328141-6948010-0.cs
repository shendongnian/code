    public struct NotificaitonSettings<T>
    {
        public Predicate<T> Predicate;
        public NotificationService Service;
    }
    public class NotificationServiceFactory<T> : INotificationServiceFactory<T>
    {
        protected static List<NotificaitonSettings<T>> settings = new List<NotificaitonSettings<T>>();
        static NotificationServiceFactory()
        {
            settings.Add(new NotificaitonSettings<T>
            {
                Predicate = m => !String.IsNullOrEmpty(m.Email),
                Service = new NotificationService(new EmailNotification(), new EmailFormatter())
            });
            settings.Add(new NotificaitonSettings<T>
            {
                Predicate = m => !String.IsNullOrEmpty(m.Fax),
                Service = new NotificationService(new FaxNotification(), new FaxFormatter())
            });
        }
        public NotificationService Create(T model)
        {
            return settings.FirstOrDefault(s => s.Predicate(model)).Service;
        }
    }
