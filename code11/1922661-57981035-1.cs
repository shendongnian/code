            public ProcessStartInfo CreateForListening()
            {
                return new ProcessStartInfo
                {
                    FileName = @"C:\ProgramData\Anaconda2\python.exe",
                    Arguments = @"D:\new_test.py listen",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
            }
            Process process = null;
            public void Listen()
            {
                var startInfo = CreateForListening();
                if (process != null)
                {
                    process.Kill();
                }
                process = Process.Start(startInfo);
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.EnableRaisingEvents = true;
                process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    Console.WriteLine("Input: " + e.Data);
                };
    
                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                {
                    Console.WriteLine("Error: " + e.Data);
                };
    
            }
