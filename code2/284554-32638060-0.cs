    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)        
            {
    
                Microsoft.Win32.SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
    
                Microsoft.Win32.SystemEvents.DisplaySettingsChanging += SystemEvents_DisplaySettingsChanging;
    
                Console.Read();
            }
    
            static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
            {
                Console.WriteLine("Display settings have been changed.");
            }
    
            static void SystemEvents_DisplaySettingsChanging(object sender, EventArgs e)
            {
                Console.WriteLine("Display settings are changing now...");
            }
    
        }
    }
