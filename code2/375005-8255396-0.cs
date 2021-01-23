	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new MainForm() );
		}
	}
	public partial class MainForm: Form
	{
		FormSplash dlg = null;
		void ShowSplashScreen()
		{
			var t = new Thread( () =>
				{
					using ( dlg = new FormSplash() ) dlg.ShowDialog();
				}
			);
			t.SetApartmentState( ApartmentState.STA );
			t.IsBackground = true;
			t.Start();
		}
		void CloseSplashScreen()
		{
			dlg.Invoke( ( MethodInvoker ) ( () => dlg.Close() ) );
		}
		public MainForm()
		{
			ShowSplashScreen();
			InitializeComponent();
			Thread.Sleep( 3000 ); // simulate big form
			CloseSplashScreen();
		}
	}
