    [STAThread]
    static void Main()
    {
    	Mutex mutex = new System.Threading.Mutex(false, "MyUniqueMutexName");
    	try
    	{
    		if (mutex.WaitOne(0, false))
    		{
    			// Run the application
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new MainForm());
    		}
    		else
    		{
    			MessageBox.Show("An instance of the application is already running.");
    		}
    	}
    	finally
    	{
    		if (mutex != null)
    		{
    			mutex.Close();
    			mutex = null;
    		}
    	}
    }
