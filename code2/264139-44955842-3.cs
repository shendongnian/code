    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Length > 0)
            {                
				List<string> lowercaseArgs = e.Args.ToList().ConvertAll(x => x.ToLower());
				if (AllocConsole(ATTACH_PARENT_PROCESS))
                {
				    // your console app code                
        
                    Console.Write("\rPress any key to continue...");
                    Console.ReadKey();
                    FreeConsole();
                    Shutdown();
                }
            }
            else
            {
			    var window = new MainWindow();
				window.Show();
            }
        }
        
        private const int ATTACH_PARENT_PROCESS = -1;
        [DllImport("kernel32", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
    }
