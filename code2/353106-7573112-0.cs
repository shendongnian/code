    static void Main()
    {
        try
        {
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(OnGuiUnhandedException);
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            var form = new MainForm();
            form.ShowDialog();
        }
        catch (Exception e)
        {
            HandleUnhandledException(e);
        }
        finally
        {
            // Do stuff
        }
    }
    private static void HandleUnhandledException(Object o)
    {
        // TODO: Log it!
        Exception e = o as Exception;
        if (e != null)
        {
        }
    }
    private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e)
    {
        HandleUnhandledException(e.ExceptionObject);
    }
    private static void OnGuiUnhandedException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        HandleUnhandledException(e.Exception);
    }
