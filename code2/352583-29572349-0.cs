        public partial class App : Application
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool AttachConsole(uint dwProcessId);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool FreeConsole();
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern int GetConsoleTitle(System.Text.StringBuilder sbTitle, int capacity);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern bool SetConsoleTitle(string sTitle);
    
            [STAThread]
            public static int Main(string[] args)
            {
                Boolean hasExceptionOccured = false;
    
                System.Text.StringBuilder sbTitle = new System.Text.StringBuilder();
    
                try
                {
                    // If the user does not provide any parameters assume they want to run in GUI mode.
                    if (0 == args.Length)
                    {
                        var application = new App();
                        application.InitializeComponent();
                        application.Run();
                    }
                    else
                    {
                        const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;  // Default value if not specifying a process ID.
    
                        // Attach to the console which launched this application.
                        AttachConsole(ATTACH_PARENT_PROCESS);
    
                        // Get the current title of the console window.
                        GetConsoleTitle(sbTitle, 64);
    
                        // Set the console title to the name and version of this application.
                        SetConsoleTitle(Global.thisProgramsName + " - v" + Global.thisProductVersion);
    
                        // Create a instance of your console class and call it’s Run() method.
                        var mainConsole = new ReportTester.MainConsole();
                        mainConsole.Run(args);                   
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.StackTrace);
                    if (null != ex.InnerException)
                    {
                        System.Console.WriteLine(ex.InnerException.Message);
                        System.Console.WriteLine(ex.InnerException.StackTrace);
                    }
                    hasExceptionOccured = true;
                }
                finally
                {
                    // Since the console does not display the prompt when freed, we will provide one here.
                    System.Console.Write(">");
    
                    // Restore the console title.
                    SetConsoleTitle(sbTitle.ToString());
    
                    // Free the console.
                    FreeConsole();
                }
    
                return (hasExceptionOccured ? 1 : 0);
            }
        }
