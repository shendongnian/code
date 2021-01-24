    [StructLayout(LayoutKind.Sequential)]
    private struct LibInformation
    {
        public IntPtr Version;
        public IntPtr Name;
        public IntPtr Date;
    }
    
    static void Main(string[] args)
    {
        // Create 3 pointers and allocate them
        IntPtr ptrVersion = Marshal.AllocHGlobal(100);
        IntPtr ptrName = Marshal.AllocHGlobal(100);
        IntPtr ptrDate = Marshal.AllocHGlobal(100);
    
        // Then declare LibInformation and assign
        LibInformation infos = new LibInformation();
    
        // Assign
        infos.Version = ptrVersion;
        infos.Name = ptrName;
        infos.Date = ptrDate;
    
        // Call function
        GetInfos(out infos);
    
        var version = Marshal.PtrToStringAnsi(data.Version);
        var name = Marshal.PtrToStringAnsi(data.Name);
        var date = Marshal.PtrToStringAnsi(data.Date);
    
        Console.ReadLine();
    }
    
    
    [DllImportAttribute("MyLibrary.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetInfos")]
    private static extern void GetInfos(out LibInformation test); // Changing IntPtr to LibInformation
