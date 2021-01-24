    try
    {
        var stackTrace = new StackTrace();
        string callingMethod = stackTrace.GetFrame(1).GetMethod().Name;
        string callingClass = stackTrace.GetFrame(1).GetMethod().ReflectedType.Name;
        string logText = string.Format(format, DateTime.Now, "INFO", callingClass, callingMethod, message);
        if (!Directory.Exists("log"))
            Directory.CreateDirectory("log");
        using (var sw = new StreamWriter(logFilePath, true))
        {
            sw.WriteLine(logText);
        } 
    }
    catch(IOException)
    {
        Console.WriteLine("Processes locking the file:");
        var lockingProcesses = FileHelper.WhoIsLocking(logFilePath);
        foreach (Process p in lockingProcesses)
            Console.WriteLine("Process: " + p.ProcessName + "   Machine:" + p.MachineName);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("The following log could not be written to file: " + message);
        Console.WriteLine("Error: " + ex.Message);
        Console.ResetColor();
    }
