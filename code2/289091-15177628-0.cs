            // executable: "c:\\python27\\python.exe", arguments: "myscript.py"
            ProcessStartInfo startInfo = new ProcessStartInfo(executable, arguments);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = textBoxWorkingDirectory.Text;
            try
            {
                Process p = new Process();
                p.StartInfo = startInfo;
                p.EnableRaisingEvents = true;
                p.OutputDataReceived += new DataReceivedEventHandler(OnDataReceived);
                p.ErrorDataReceived += new DataReceivedEventHandler(OnDataReceived);
                p.Exited += new EventHandler(OnProcessExit);
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
            }
