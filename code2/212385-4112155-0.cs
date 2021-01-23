    var proc = new Process()
    {
        StartInfo = new ProcessStartInfo(@"SomeProcess.exe")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
        }
    };
    if (!proc.Start())
    {
        // handle error
    }
    var stdout = proc.StandardOutput;
    string line;
    while ((line = stdout.ReadLine()) != null)
    {
        // process and print
        Process(line);
        Console.WriteLine(line);
    }
