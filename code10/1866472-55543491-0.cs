    public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			UIApplication.Main (args, "MYCUSTOMAPP", "AppDelegate");
		}
	}
	[Register ("MYCUSTOMAPP")]
	public class MYCUSTOMAPP : UIApplication
	{ 
		const int TimeoutInSeconds = 1800; // 30 minutes
		NSTimer idleTimer;
		public override void SendEvent (UIEvent uievent)
		{
			base.SendEvent (uievent);
			if (idleTimer == null)
				ResetTimer ();
			var allTouches = uievent.AllTouches;
			if (allTouches != null && allTouches.Count > 0 && ((UITouch)allTouches.First ()).Phase == UITouchPhase.Began)
				ResetTimer ();
		}
		void ResetTimer ()
		{
			if (idleTimer != null)
				idleTimer.Invalidate ();
			idleTimer = NSTimer.CreateScheduledTimer (new TimeSpan (0, 0, TimeoutInSeconds), (t) => TimerExceeded());
		}
		void  TimerExceeded ()
		{
			NSNotificationCenter.DefaultCenter.PostNotificationName ("TimeoutNotification", null);
		}
	}
