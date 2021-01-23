    [Application]
    public class MyApplication : Application
    {
    	public static string StaticString { get; set; }
    
    	public string InstanceString { get; set; }
    
        public MyApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
    }
