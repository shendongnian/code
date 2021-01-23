    string filelocation = Assembly.GetExecutingAssembly().Location;
    string filename = Process.GetCurrentProcess().MainModule.ModuleName;
    filename = filename.Replace(".exe", "");
    Process[] processArray = Process.GetProcesses();
    int processesExists = 0;
    for (int i2 = 0; i2 < (processArray.Length - 1); i2++)
    {
        if (processArray[i2].ProcessName.Contains(filename))
        {
            processesExists++;
        }
    }
    if (processesExists == 1 && !Console.Title.Contains("cmd"))
    {
        Process.Start("cmd.exe", "/C " + "\"" + filelocation + "\"");
    }
    if (!Console.Title.Contains("cmd"))
    {
        Process.GetCurrentProcess().Kill();
    }
