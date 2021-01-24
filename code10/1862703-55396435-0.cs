    private static void Main(string[] args)
    {
        Console.WriteLine("Press escape to quit");
        do
        {
            while (!Console.KeyAvailable)
            {
                RunBatch();
                Thread.Sleep(1000);
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        Console.WriteLine("While loop has exited");
        Console.ReadLine();
    }
    private static void RunBatch()
    {
        var process = new Process
        {
            StartInfo =
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = @"C:\Dev\Batch\GetTcpConnections.bat"
            }
        };
        process.Start();
        Console.WriteLine(process.StandardOutput.ReadToEnd());
    }
