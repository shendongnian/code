	private static IUserInterface menu;
	[STAThread]
	static void Main(string[] args)
	{
		bool closeApp = false;
        // because the both classes implements the IUserInterface interface,
        // the both can be typecast to IUserInterface 
		IUserInterface menu = new MyUserInterface();
		
		// OR
		//IUserInterface menu = new MyOtherUserInterface();
		
		do
		{
			proxy.PrintMenu();
			int command;
			Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out command);
			Console.WriteLine();
			closeApp = proxy.SendMenuCommand(command);
		} while (!closeApp);
		// Aplikacija ugasena
		Console.WriteLine("Application closed successfully. Press any key...");
		Console.ReadKey();
	}
