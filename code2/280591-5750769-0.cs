    ProcessStartInfo processStartInfo = new ProcessStartInfo("EXCEL.EXE");
    Process process = new Process();
    process.StartInfo = processStartInfo;
    if (!process.Start())
    {
        // That didn't work
    }
