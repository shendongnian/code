	class Program
	{
		static void Main(string[] args)
		{
			Car myCar = new Car();
			bool processCancelled = false;
			myCar.SubscribeOnError(CarOnError).Paint(ref processCancelled, "red").Sell(ref processCancelled, 25000d);
		}
		public static bool CarOnError(Exception e)
		{
			// Log exception
			// Decide if must cancel
			return true;
		}
	}
	public class Car
	{
		private Func<Exception, bool> onErrorMethod = null;
		public Car SubscribeOnError(Func<Exception, bool> methodToCall)
		{
			onErrorMethod = methodToCall;
			return this;
		}
		public Car Paint(ref bool cancelled, string color)
		{
			if (cancelled) return this;
			try
			{
				// Do stuff
			}
			catch (Exception exc)
			{
				cancelled = onErrorMethod == null ? true : onErrorMethod(exc);
			}
			return this;
		}
		public Car Sell(ref bool cancelled, double price)
		{
			if (cancelled) return this;
			try
			{
				// Do stuff
			}
			catch (Exception exc)
			{
				cancelled = onErrorMethod == null ? true : onErrorMethod(exc);
			}
			return this;
		}
	}
