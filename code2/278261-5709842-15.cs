    using System;
    using System.Runtime.InteropServices;
    
    namespace PoC
    {
        class MainClass
        {
            [DllImportAttribute("libtracehelper.so")] extern static string CurrentMethodFullName();
            [DllImportAttribute("libtracehelper.so")] extern static uint CurrentMethodId();
    
    		static MainClass()
    		{
                Console.WriteLine ("TRACE 0 {0:X8} {1}", CurrentMethodId(), CurrentMethodFullName());
    		}
    
            public static void Main (string[] args)
    		{
    			Console.WriteLine ("TRACE 1 {0:X8} {1}", CurrentMethodId(), CurrentMethodFullName());
    			{
    				var instance = new MainClass();
    				instance.OtherMethod();
    			}
    			Console.WriteLine ("TRACE 2 {0:X8} {1}", CurrentMethodId(), CurrentMethodFullName());
    			{
    				var instance = new MainClass();
    				instance.OtherMethod();
    			}
    			Console.WriteLine ("TRACE 3 {0:X8} {1}", CurrentMethodId(), CurrentMethodFullName());
    			Console.Read();
    		}
    
            private void OtherMethod()
            {
                ThirdMethod();
                Console.WriteLine ("TRACE 4 {0:X8} {1}", CurrentMethodId(), CurrentMethodFullName());
            }
    
            private void ThirdMethod()
            {
                Console.WriteLine ("TRACE 5 {0:X8} {1}", CurrentMethodId(), CurrentMethodFullName());
            }
        }
    }
