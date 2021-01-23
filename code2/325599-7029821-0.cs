    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]  
    public struct DeviceInfo  
    {
        public UInt32 handle;  
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 80)]  
        public String name;  
        public UInt32 unique_ID;  
    }
    
    [DllImportAttribute("MyC++API.dll", EntryPoint = "get_device_info", CallingConvention = CallingConvention.StdCall)]  
    public static extern int get_device_info(
        [In, Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] DeviceInfo[] di,
        int length_of_di_array,
        ref int p_numValidDevices);
    
    static void Main()
    {
    
        int numValidDevices = 0;
    
        DeviceInfo[] di = new DeviceInfo[16];
    
        get_device_info(di, 16, ref numValidDevices);
    
        for (int i = 0; i < numValidDevices; ++i)
        {
            Console.WriteLine("Handle: {0}\nName: {1}\nUnique ID: {2}", di[i].handle, di[i].name, di[i].unique_ID);
        }
    
        Console.ReadLine();
        API_close();
    }
