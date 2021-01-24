    [STAThread]
    [HandleProcessCorruptedStateExceptions, SecurityCritical]
    static void Main()
    {
        try
        {
            // add UnhandledException handler
            // AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            // * in this particular case is not quite useful to handle this exceptions,
            //   because you already wrap your entire application in a try/catch block
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        catch (Exception ex)
        {
            // handle it somehow
        }
    }
