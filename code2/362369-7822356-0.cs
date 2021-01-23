	public class Subscriber : IObserver<int>
	{
		public void OnNext(int a)
		{
			Console.WriteLine("{0} on {1} at {2}",
				a,
				Thread.CurrentThread.ManagedThreadId,
				DateTime.Now.ToString());
		}
		public void OnError(Exception e)
		{ }
		public void OnCompleted()
		{ }
	} 
