    using System;
    using System.Runtime.InteropServices;
    namespace PoC
    {
	    class MainClass
	    {
		    static readonly uint FixedBaseAddress = TraceHelperStackId(); // just a random base address
		
		    [DllImportAttribute("libtracehelper.so")]
		    extern static uint TraceHelperStackId();
		
		    public static void Main (string[] args)
		    {
			    Console.WriteLine ("FixedBaseAddress for this process: {0:X8}", FixedBaseAddress);
			    var instance = new MainClass();
			    Console.WriteLine ("TRACE 2 {0:X8}", (TraceHelperStackId()-FixedBaseAddress));
			    instance.OtherMethod();
			    Console.WriteLine ("TRACE 3 {0:X8}", (TraceHelperStackId()-FixedBaseAddress));
			    instance.OtherMethod();
			    instance = new MainClass();
			    instance.OtherMethod();
			    instance.OtherMethod();
		    }
		
		    private void OtherMethod()
		    {
			    Console.WriteLine ("TRACE 4 {0:X8}", (TraceHelperStackId()-FixedBaseAddress));
			    ThirdMethod();
		    }
		    private void ThirdMethod()
		    {
			    Console.WriteLine ("TRACE 5 {0:X8}", (TraceHelperStackId()-FixedBaseAddress));
		    }
	    }
    }
