        class Program
        {
            static Process webAPI;
        
            static async Task Main(string[] args)
            {
                AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        
                webAPI = new Process
                {
                    StartInfo = new ProcessStartInfo("dotnet")
                    {
                        UseShellExecute = false,
                        CreateNoWindow = true,
    
                        //If you want to run as .exe
                        FileName = @"C:\Project\bin\Debug\netcoreapp2.2\publish\WebAPI.exe",
    
                        //If you want to run the .dll
                        WorkingDirectory = "C:/Project/publish",
                        Arguments = "WebAPI.dll"
                    }
                };
                using (webAPI)
                {
                    webAPI.Start();
                    webAPI.WaitForExit();
                }
            }
        
            static void CurrentDomain_ProcessExit(object sender, EventArgs e)
            {
                webAPI.Close();
            }
        }
