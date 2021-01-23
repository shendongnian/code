    using System;
    using System.Runtime.InteropServices;
    
    namespace PoC
    {
        class MainClass
        {
            [DllImportAttribute("libtracehelper.so")] extern static string TraceHelperStackId();
    
    		static MainClass()
    		{
                Console.WriteLine ("TRACE 0 {0}", TraceHelperStackId());
    		}
    
            public static void Main (string[] args)
    		{
    			Console.WriteLine ("TRACE 1 {0}", TraceHelperStackId());
    			{
    				var instance = new MainClass();
    				instance.OtherMethod();
    			}
    			Console.WriteLine ("TRACE 2 {0}", TraceHelperStackId());
    			{
    				var instance = new MainClass();
    				instance.OtherMethod();
    			}
    			Console.WriteLine ("TRACE 3 {0}", TraceHelperStackId());
    			Console.Read();
    		}
    
            private void OtherMethod()
            {
                ThirdMethod();
                Console.WriteLine ("TRACE 4 {0}", TraceHelperStackId());
            }
    
            private void ThirdMethod()
            {
                Console.WriteLine ("TRACE 5 {0}", TraceHelperStackId());
            }
        }
    }
