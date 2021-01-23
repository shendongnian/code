	public class Service : ServiceBase
	{
		protected override void OnStart(string[] args)
		{
			// Start logic here.
		}
		protected override void OnStop()
		{
			// Stop logic here.
		}
		static void Main(string[] args)
		{
			using (var service = new Service()) {
				if (Environment.UserInteractive) {
					service.Start();
					Thread.Sleep(Timeout.Infinite);
				} else
					Run(service);
			}
		}
		public void Start() => OnStart(null);
	}
