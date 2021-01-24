    public static class NotificationsResourceHandler
	{
		private static readonly IHubContext myContext;		 
		public static Dictionary<string, string> Groups;
		static NotificationsResourceHandler()
		{
			myContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();   
			Groups = new Dictionary<string, string>();
		}
		public static void BroadcastNotification(dynamic model, NotificationType notificationType, string userName)
		{
			myContext.Clients.Group(userName).PushNotification(new { Data = model, Type = notificationType.ToString() });
		}
	}
