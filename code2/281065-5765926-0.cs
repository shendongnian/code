    int memory;
    Process[] application;
    application = Process.GetProcessesByName("MyApplication.exe");
    applicationMemory = application[0].PrivateMemorySize;
    Console.WriteLine("Memory used: {0}.", applicationMemory);
