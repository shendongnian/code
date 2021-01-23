    class MyClass
    {
    private delegate void WriteLog_Delegate([MarshalAs(UnmanagedType.LPWStr)]string Mess);
    private WriteLog_Delegate WriteLog;
    
    [DllImport("My.dll", EntryPoint = "?CreateContext@@YAPAVDllContext@@P6GXPB_W@Z@Z", CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr CreateContext(WriteLog_Delegate WriteLogProc);
    
    private IntPtr Context = IntPtr.Zero;
    
    public MyClass()
    {
    	this.WriteLog = new WriteLog_Delegate(this.WriteLogToConsole);
            this.Context = CreateContext(this.WriteLog);
    }
    
    private void WriteLogToConsole(string Mess)
    {
    	Console.WriteLine("Message from unmanaged code: {0}", Mess);
    }
    }
