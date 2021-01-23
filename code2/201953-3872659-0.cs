    static void Main()
    {
    AppDomain.CurrentDomain.UnhandledException += 
      new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
    }
    
    static void CurrentDomain_UnhandledException
      (object sender, UnhandledExceptionEventArgs e)
    {
      try
      {
        Exception ex = (Exception)e.ExceptionObject;
    
        MessageBox.Show("Whoops! Please contact the developers with the following" 
              + " information:\n\n" + ex.Message + ex.StackTrace, 
              "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
      }
      finally
      {
        Application.Exit();
      }
    }
