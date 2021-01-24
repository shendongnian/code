    static object ResultLock = new object();
 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="executable"></param>
    /// <param name="args"></param>
    /// <param name="exitCode"></param>
    /// <returns></returns>
    private static string ExecuteCommand(string executable, string args, out int exitCode)
    {
        exitCode = -1;
        // create the process
        var proc = new Process
        {
            EnableRaisingEvents = true,
            StartInfo =
            {
                FileName = executable,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                Arguments = args,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas"
            }
        };
        // try to start the process
        try
        {
            proc.Start();
        }
        catch (Exception ex)
        {
            return
                $"Error launching command line {executable}\n\n{ex.Message}";
        }
        var result = false;
        var messageString = new StringBuilder();
        var timeBefore = DateTime.Now;
        // Wait for process
        while (false == result && (DateTime.Now - timeBefore < new TimeSpan(0, 0, 60)))
        {
            result = proc.WaitForExit(100);
            messageString.Append(proc.StandardOutput.ReadToEnd());
        }
        if (result)
        {
            var message = messageString.ToString();
            lock (ResultLock)
            {
                // save the exitcode
                exitCode = proc.ExitCode;
            }
            return message;
        }
        try
        {
            proc.Close();
        }
        catch
        {
            // ignored
        }
        return $"Error {executable} timed out";
    }
