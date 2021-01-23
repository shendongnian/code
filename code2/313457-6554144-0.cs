        [STAThread]
		static void Main()
		{
			// Splash screen, which is terminated in MainForm.       
			SplashForm.ShowSplash();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// Run UserCost.
         Application.Run(new MainForm());
		}
