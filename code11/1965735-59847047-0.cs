	private static void RunInteractive(ServiceBase[] servicesToRun)
	{
		//Account for running this application without a console window (debugging in IDE)
		if (!ConsoleWindow.Exists() && !ConsoleWindow.Create())
			return;
		Console.WriteLine("Services running in interactive mode.");
		Console.WriteLine();
		MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart", BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (ServiceBase service in servicesToRun)
		{
			Console.Write("Starting {0}...", service.ServiceName);
			onStartMethod.Invoke(service, new object[] { new string[] { } });
			Console.Write("Started");
		}
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine("Press any key to stop the services and end the process...");
		Console.ReadKey();
		Console.WriteLine();
		MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop", BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (ServiceBase service in servicesToRun)
		{
			Console.Write("Stopping {0}...", service.ServiceName);
			onStopMethod.Invoke(service, null);
			Console.WriteLine("Stopped");
		}
		//Keep the console alive for a second to allow the user to see the message.
		Console.WriteLine("All services stopped.");
		Thread.Sleep(1000);
	}
