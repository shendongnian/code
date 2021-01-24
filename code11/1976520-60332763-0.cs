    public class PushNotificationRepository : IPushNotificationRepository
    {
        IServiceScopeFactory _serviceScopeFactory;
        public PushNotificationRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
      
        public void Add(PushNotification notification);
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PushNotificationsContext>();
                //other logic
            }
            
        }
    }
