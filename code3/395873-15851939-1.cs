                Process[] prs = Process.GetProcesses();
    
                foreach (Process pr in prs)
                {
                    if (!pr.Responding) {
    
                    try
                    {
                        pr.Kill();
                    }
                    catch { }
                }
    
                //then to restart-
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"C:\yourapp.exe"
                    }
                };
                process.Start();
        
