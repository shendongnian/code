	void Main()
	{
		WhenTaskDone
			.SelectMany(_ => Observable.FromAsync(() => StopDelivery()), (x, y) => x)
			.Subscribe(_ => Debug.WriteLine("Delivery stopped"));
	
		NiTask.OnDone();
	}
	
	private NiTaskClass NiTask = new NiTaskClass();
	
	internal IObservable<TaskDoneEventArgs> WhenTaskDone =>
		Observable
			.FromEventPattern<TaskDoneEventHandler, TaskDoneEventArgs>(
				handler => NiTask.Done += handler,
				handler => NiTask.Done -= handler)
			.Select(x => x.EventArgs);
	
	
	internal Task StopDelivery() => Task.Run(() => Console.WriteLine("StopDelivery"));
	
	public delegate void TaskDoneEventHandler(object sender, TaskDoneEventArgs e);
	
	public class TaskDoneEventArgs : EventArgs { }
	
	public class NiTaskClass
	{
		public event TaskDoneEventHandler Done;
		public void OnDone()
		{
			this.Done?.Invoke(this, new TaskDoneEventArgs());
		}
	}
