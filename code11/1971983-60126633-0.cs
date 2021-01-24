     static void Main(string[] args)
        {
    
    
            string output = "";
            var proc = new ProcessStartInfo("cmd.exe", "/c ipconfig")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = @"C:\Windows\System32\"
            };
            Process p = Process.Start(proc);
            p.OutputDataReceived += (sender, args1) => { output += args1.Data + Environment.NewLine; };
            p.BeginOutputReadLine();
            p.WaitForExit();
            Console.WriteLine(output);
    
        }
