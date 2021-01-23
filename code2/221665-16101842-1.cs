    //C#
    [StructLayout(LayoutKind.Sequential)]
    public struct Status
    {
       public IntPtr name;
       public uint state;
            
       public string getName()
       {
         if (name == IntPtr.Zero) return "<no-value>";
         return Marshal.PtrToStringUni(name);
       }
    }
    //And import function...
    [DllImport(dll, CallingConvention = CallingConvention.Winapi)]
    private static extern bool get_states(IntPtr p, [Out]MacroFlag[] flags, int flags_size);
    //And simple decoder
    public static Status[] getAll(IntPtr p, int size)
    {
       var results = new Status[size];
    
       get_states(p, results, size);
    
       return results;
    }
