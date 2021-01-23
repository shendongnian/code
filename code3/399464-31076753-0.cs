            Process p = new Process(...);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true; // Is a MUST!
            p.EnableRaisingEvents = true;
            p.OutputDataReceived += OutputDataReceived;
            p.ErrorDataReceived += ErrorDataReceived;
            Process.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
            p.OutputDataReceived -= OutputDataReceived;
            p.ErrorDataReceived -= ErrorDataReceived;
...
        void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Process line provided in e.Data
        }
        void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Process line provided in e.Data
        }
