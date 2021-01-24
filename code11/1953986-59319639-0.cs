	public class Child
	{
		public event Action<Child> OnFault;
		
		public async Task DoWork()
		{
			try {
				// you do what you gotta do
			}
			catch {
				if(OnFault !=null) OnFault(this);
			}
		}
	}
	
	public class Worker
	{
		private List<Child> subscriptions = new List<Child>();
	
		public void Subscribe(string pID)
		{
			Child temp = new Child();		
			temp.OnFault += (x) => subscriptions.Remove(x); // set an event handler to remove that particular instance from the list
			subscriptions.Add(temp);
		}
	}
