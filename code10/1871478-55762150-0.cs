            ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = fileName;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = true;
        startInfo.CreateNoWindow = false;
       // startInfo.Verb = "runas";
        var process = new Process
        {
            StartInfo = { FileName = fileName },
            EnableRaisingEvents = true
        };
        process.StartInfo = startInfo;
        process.Exited += (sender, args) =>
        {
            tcs.SetResult(process.ExitCode);
            process.Dispose();
        };
        process.Start();
