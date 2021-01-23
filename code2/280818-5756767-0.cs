	using System;
	using System.Timers;
	
	public class TimerExample
	{
		public static void Main()
		{
			Timer aTimer = new Timer();
			aTimer.Elapsed += OnTimedEvent;
			aTimer.Interval = 2000;
			aTimer.Enabled = true;
			Console.ReadLine(); // artificially pause app to let timer run
			GC.KeepAlive(aTimer);
		}
	
		private static void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			Console.WriteLine("Timer event fired");
                        // pseudocode:
                        // check for new events collected
                        // if any exist, take first and present UI to user
                        // if more exist, then consinue
		}
	}
