    using System.Runtime.InteropServices;
    
    namespace MyCSharpDLL
    {
        class PlatformInvokeTest
        {
            // Import C++ DLL
            [DllImport("SubscribeMessages.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern void DispatchEvents();
    
            static void LoadFilterEVENT(/*LoadFilterEVENTMessage msg*/)
            {
                //FilterValue = msg.Filter;
                DispatchEvents();
            }
    
            /* Methods in DLL being used below  */
            public static void Main()
            {
                LoadFilterEVENT();
            }
        };
    }
