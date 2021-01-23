    static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
            CS = new ConsoleServer();
            CS.Run();            
        }
        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;
            Logger.Log("UNHANDLED EXCEPTION : " + e.ExceptionObject.ToString());
            Process.Start(@"C:\xxxx\bin\x86\Release\MySelf.exe");
        }
