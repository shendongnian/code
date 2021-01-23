    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = fullPath;
    startInfo.Arguments = args;
    startInfo.RedirectStandardOutput = true;
    startInfo.RedirectStandardError = true;
    startInfo.UseShellExecute = false;
    startInfo.CreateNoWindow = true;
    Process processTemp = new Process();
    processTemp.StartInfo = startInfo;
    processTemp.EnableRaisingEvents = true;
    try
    {
        processTemp.Start();
    }
    catch (Exception e)
    {
        throw;
    }
