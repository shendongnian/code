		[STAThread]
		static void Main()
		{
			Kernel32.DisableUMCallbackFilter();
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
