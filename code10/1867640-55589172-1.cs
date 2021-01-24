    [DllImport("Msprintsdk.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetInit", CharSet = CharSet.Ansi)]
        public static extern unsafe int SetInit();
    
    var res = SetPrintport(new StringBuilder("USB001"),0);
    
    if (res == 0)
    {
        Console.WriteLine("Printer Setup Successful.");
    }
    else
    {
        Console.WriteLine("Printer Setup Un-Successful.");
        Console.ReadKey();
        Environment.Exit(0);
    }
