		    static class Program
    {
        public static ApplicationContext AppContext { get;  set; }
		
		static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Save app context
            Program.AppContext = new ApplicationContext(new LoginForm());
            Application.Run(AppContext);
        }
		
		//helper method to switch forms
		  public static void SwitchMainForm(Form newForm)
        {
            var oldMainForm = AppContext.MainForm;
            AppContext.MainForm = newForm;
            oldMainForm?.Close();
            newForm.Show();
        }
		
	}
