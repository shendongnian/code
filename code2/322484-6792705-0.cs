	private static void Main(string[] args) {
		if (Environment.UserInteractive) {
			Console.WriteLine("My Service");
			Console.WriteLine();
			switch (args.FirstOrDefault()) {
			case "/install":
				ManagedInstallerClass.InstallHelper(new[] {Assembly.GetExecutingAssembly().Location});
				break;
			case "/uninstall":
				ManagedInstallerClass.InstallHelper(new[] {"/u", Assembly.GetExecutingAssembly().Location});
				break;
			case "/interactive":
				using (MyService service = new MyService(new ConsoleLogger())) {
					service.Start(args.Skip(1));
					Console.ReadLine();
					service.Stop();
				}
				break;
			default:
				Console.WriteLine("Supported arguments:");
				Console.WriteLine(" /install      Install the service");
				Console.WriteLine(" /uninstall    Uninstall the service");
				Console.WriteLine(" /interactive  Run the service interactively (on the console)");
				break;
			}
		} else {
			ServiceBase.Run(new MyService());
		}
	}
