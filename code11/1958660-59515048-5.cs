    Console.WriteLine("Press Enter to put the process onto Core 1");
    Console.ReadLine();
    Process Proc = Process.GetCurrentProcess();
    long AffinityMask = (long)Proc.ProcessorAffinity;
    AffinityMask &= 0x0001; // Put my process on the First Core
    Proc.ProcessorAffinity = (IntPtr)AffinityMask;
    Console.WriteLine("Process is now on Core 1");
    Console.WriteLine("Press Enter to exit");
    Console.ReadLine();
