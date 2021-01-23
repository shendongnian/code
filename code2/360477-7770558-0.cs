    [DllImport("kernel32")]
    static extern IntPtr GetCommandLine();
    static void DoIt()
    {
        IntPtr pcmdline = GetCommandLine();
        Console.WriteLine("Environment.CommandLine = {0}", Environment.CommandLine);
        string realCmdLine = Marshal.PtrToStringAnsi(pcmdline);
        Console.WriteLine("realCmdLine = {0}", realCmdLine);
        Console.WriteLine("** Modify command line");
        // Modify the command line
        byte[] bytes = Encoding.ASCII.GetBytes("ham and swiss on rye\0");
        Marshal.Copy(bytes, 0, pcmdline, bytes.Length);
        Console.WriteLine("Environment.CommandLine = {0}", Environment.CommandLine);
        pcmdline = GetCommandLine();
        realCmdLine = Marshal.PtrToStringAnsi(pcmdline);
        Console.WriteLine("realCmdLine = {0}", realCmdLine);
    }
