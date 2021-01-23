    [StructLayout(
        LayoutKind.Sequential,      //must specify a layout
        CharSet = CharSet.Ansi)]    //if you intend to use char
    public struct ToBePassed
    {
        public Int32 Num1;
        public Int32 Num2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public Char[] Data;    //specify the size using MarshalAs
    }
    [DllImport("...")]
    public static extern void APICall(IntPtr argPtr);
    
    public static void CallFunction(ToBePassed managedObj)
    {
        IntPtr unmanagedAddr = Marshal.AllocHGlobal(Marshal.SizeOf(managedObj));
        Marshal.StructureToPtr(managedObj, unmanagedAddr, true);
        APICall(unmanagedAddr);
        Marshal.PtrToStructure(unmanagedAddr, managedObj);
        Marshal.FreeHGlobal(unmanagedAddr);
        unmanagedAddr = IntPtr.Zero;
    }
