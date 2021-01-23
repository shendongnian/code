	public sealed class SingleInstanceApplication : WindowsFormsApplicationBase
	{
		private static SingleInstanceApplication _application;
		private SingleInstanceApplication()
		{
			base.IsSingleInstance = true;
		}
		public static void Run(Form form)
		{
			_application = new SingleInstanceApplication {MainForm = form};
			_application.StartupNextInstance += NextInstanceHandler;
			_application.Run(Environment.GetCommandLineArgs());
		}
		static void NextInstanceHandler(object sender, StartupNextInstanceEventArgs e)
		{
			// Do whatever you want to do when the user launches subsequent instances
			// like when the user tries to restart the application again, the main window is activated again.
			_application.MainWindow.WindowState = FormWindowState.Maximized;
		}
	}
