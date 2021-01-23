    class Program
	{
		static void Main(string[] args)
		{
			DoSomething.OnNeedsUI += new EventHandler<EventArgs>(DoSomething_OnNeedsUI);
			Thread t = new Thread(new ThreadStart(DoSomething.Work));
			t.Start();
		}
		private static void DoSomething_OnNeedsUI(object sender, EventArgs e)
		{
			Console.Write("Call Back Handled Here");
		}
	}
	public static class DoSomething
	{
		public static void Work()
		{
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(5000);
				// Raise your Event so the tUI can respond
				RaiseOnNeedsUI();
			}
		}
	
		//	Create a Customer Event that your UI will Register with
		public static event EventHandler<EventArgs> OnNeedsUI;
		private static void RaiseOnNeedsUI()
		{
			if (OnNeedsUI != null)
				OnNeedsUI(null, EventArgs.Empty);
		}
