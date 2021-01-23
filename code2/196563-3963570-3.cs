    string tempFile = Path.GetTempFileName();
    Mutex handle = new Mutex(true, typeof(Program).Namespace + "-self-debugging");
    try
    {
        Process pDebug = Process.Start(typeof(Program).Assembly.Location,
            "debug-dump " + Process.GetCurrentProcess().Id + " " + tempFile);
        if (pDebug != null)
            pDebug.WaitForExit();
    }
    catch { }
    finally
    {
        handle.ReleaseMutex();
    }
    Console.WriteLine(File.ReadAllText(tempFile));
