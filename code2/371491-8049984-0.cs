	class Program
	{
		static Application app;
		static void Main(string[] args)
		{
			var appthread = new Thread(new ThreadStart(() =>
				{
					app = new Application();
					app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
					app.Run();
				}));
			appthread.SetApartmentState(ApartmentState.STA);
			appthread.Start();
			while (true)
			{
				var key =Console.ReadKey().Key;
				// Press 1 to create a window
				if (key == ConsoleKey.D1)
				{
					// Use of dispatcher necessary as this is a cross-thread operation
					DispatchToApp(() => new Window().Show());
				}
				// Press 2 to exit
				if (key == ConsoleKey.D2)
				{
					DispatchToApp(() => app.Shutdown());
					break;
				}
			}
		}
		static void DispatchToApp(Action action)
		{
			app.Dispatcher.Invoke(action);
		}
	}
