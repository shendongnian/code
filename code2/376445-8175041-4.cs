    static class EventRaiser
	{
		public static void Raise(EventHandler handler, object sender, EventArgs args)
		{
			handler(sender, args);
		}
		
		public static void Raise(EventHandler handler, object sender)
		{
			Raise(handler, sender, EventArgs.Empty);
		}
	}
