    static void Main()
    {
        using (Process p = new Process())
        {
            p.StartInfo = new ProcessStartInfo
            {
                FileName = @"netstat.exe",
                Arguments = "-n",                                        
                RedirectStandardOutput = true,
                UseShellExecute = false                    
            };
            p.EnableRaisingEvents = true;
            using (ManualResetEvent mre = new ManualResetEvent(false))
            {
                p.Exited += (s, e) => mre.Set();
                p.Start();
                mre.WaitOne();
            }
    
            Console.WriteLine(p.StandardOutput.ReadToEnd());
        }           
    }
