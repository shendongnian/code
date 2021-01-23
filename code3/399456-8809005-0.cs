            Process p = new Process();
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = @"C:\Program Files (x86)\gnuwin32\bin\ls.exe";
            p.StartInfo.Arguments = "-R C:\\";
            p.OutputDataReceived += new DataReceivedEventHandler(
                (s, e) => 
                { 
                    Console.WriteLine(e.Data); 
                }
            );
            p.ErrorDataReceived += new DataReceivedEventHandler((s, e) => { Console.WriteLine(e.Data); });
            p.Start();
            p.BeginOutputReadLine();
