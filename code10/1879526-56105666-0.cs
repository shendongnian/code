    [STAThread]
    static void Main()
    {
        // add UnhandledException handler
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
    private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        // prepare message for user
        var message = "There was an unknown exception while running <app_name>!";
        var exception = e.ExceptionObject as Exception;
        if (exception != null)
        {
            // change message if there was actual exception
            message = $"There was an {exception.GetType().Name} exception while running <app_name>! {exception.Message}";
            // adding inner exceptions messages
            var innerException = exception.InnerException;
            while (innerException != null)
            {
                message += $"\r\n-> {innerException.GetType().Name}: {innerException.Message}";
                innerException = innerException.InnerException;
            }
    #if DEBUG
            // add tracing info
            message += $"\r\n\r\n{GetStackTrace(exception)}";
    #endif
        }
        if (e.IsTerminating) message += "\r\n\r\n<app_name> will be closed.";
        // showing message to the user
        MessageBox.Show(message, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    #if DEBUG
    private static string GetStackTrace(Exception exception)
    {
        var trace = new System.Diagnostics.StackTrace(exception, fNeedFileInfo: true);
        var frames = trace.GetFrames()
            .Select((f, i) => {
                var filename = f.GetFileName();
                var methodInfo = f.GetMethod();
                var frame = $"#{i} in the method {methodInfo.DeclaringType.FullName}.{methodInfo.Name}()";
                if (filename != null) frame += $" (source file: {System.IO.Path.GetFileName(filename)}@{f.GetFileLineNumber()}:{f.GetFileColumnNumber()})";
                return frame;
            });
        return $"Full stack trace ({trace.FrameCount} frames total):\r\n{string.Join("\r\n", frames)}";
    }
    #endif
