	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			var app = new MyApp(new Form1());
			app.Run(args);
		}
	}
	internal class MyApp : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
	{
		public MyApp(Form mainForm)
		{
			this.EnableVisualStyles = true;
			this.SaveMySettingsOnExit = true;
			this.IsSingleInstance = true;
			this.MainForm = mainForm;
		}
	}
