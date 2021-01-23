	public class SomeOtherClass
	{
		public void ResponseToSomeEvent()
		{
			var proxy = new Proxy();
			// Assign the lambda to a local variable
			EventHandler doSomething = (sender, e) => Console.WriteLine("Just Once");
			
			// Subscribe to event
			proxy.SomeEvent += doSomething;
			proxy.Raise();
			// Unsubscribe and resubscribe to event
			proxy.SomeEvent -= doSomething;
			proxy.SomeEvent += doSomething;
			proxy.Raise();
		}
	}
	public class Proxy
	{
		public event EventHandler SomeEvent;
		public void Raise()
		{
			Console.WriteLine("Raise");
			SomeEvent(this, EventArgs.Empty);
		}
	}
