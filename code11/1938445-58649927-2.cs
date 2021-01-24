    public class MyWebHookHandler : WebHookHandler
    {
        public MyWebHookHandler()
        {
            this.Receiver = "custom";
        }
    
        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            CustomNotifications notifications = context.GetDataOrDefault<CustomNotifications>();
            foreach (var notification in notifications.Notifications)
            {
                ...
            }
            return Task.FromResult(true);
        }
    }
