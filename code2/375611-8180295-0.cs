    string filplacering = Assembly.GetExecutingAssembly().Location;
    Process[] ProcessArray = Process.GetProcesses();
    int ProcessesExists = 0;
    for (int i2 = 0; i2 < (ProcessArray.Length - 1); i2++)
    {
        if (ProcessArray[i2].ProcessName.Contains("PingListe"))
        {
            ProcessesExists++;
        }
    }
    if (ProcessesExists == 1 && !Console.Title.Contains("cmd"))
    {
        Process.Start("cmd.exe", "/C " + "\"" + filplacering + "\"");
    }
    if (!Console.Title.Contains("cmd"))
    {
        Process.GetCurrentProcess().Kill();
    }
