	public static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		// catch app errors
		Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
		try
		{
			Application.Run(new Form());
		}
		catch (Exception exc)
		{
			// show popupform
			PopupForm popup = new PopupForm();
			if(popup.ShowDialog() == DialogResult.OK)
			{
				Application.Restart();
			}
			else
			{
				Application.Exit();
			}
		}
	}
