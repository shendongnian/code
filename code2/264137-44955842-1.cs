    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Length > 0)
            {                
				AllocConsole();
				List<string> lowercaseArgs = e.Args.ToList().ConvertAll(x => x.ToLower());
				// your console app code                
        
                Console.WriteLine("Press enter to finish");
                Console.ReadLine();
                Shutdown();
            }
            else
            {
				var window = new MainWindow();
				window.Show();
            }
        }
        
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
    }
