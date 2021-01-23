    ProcessStartInfo processStartInfo = new ProcessStartInfo("path", "args");
    processStartInfo.Verb = "runas";
    using (Process process = new Process())
    {
       process.StartInfo = processStartInfo;
       process.Start();
       process.WaitForExit();
    }
