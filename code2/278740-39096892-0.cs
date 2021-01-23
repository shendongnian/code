    using System.Runtime.InteropServices;
    
    ...
    void MyConsoleHandler()
    {
        if (AllocConsole())
        {
            Console.Out.WriteLine("Input some text here: ");
    		string UserInput = Console.In.ReadLine();
    
            FreeConsole();
        }
    }
    
    
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
    
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool FreeConsole();
