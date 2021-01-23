    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    
    class Program {
        static void Main() {
            Object so = Activator.CreateInstance(Type.GetTypeFromProgID("SAPI.SpVoice"));
            string[] rgsNames = new string[1];
            int[] rgDispId = new int[1];
            rgsNames[0] = "Speak";
            IDispatch disp = (IDispatch)so;
            Guid dummy = Guid.Empty;
            disp.GetIDsOfNames(ref dummy, rgsNames, 1, 0x800, rgDispId);
            Console.WriteLine(rgDispId[0]);
        }
    
        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00020400-0000-0000-C000-000000000046")]
        private interface IDispatch {
            int GetTypeInfoCount();
            [return: MarshalAs(UnmanagedType.Interface)]
            ITypeInfo GetTypeInfo([In, MarshalAs(UnmanagedType.U4)] int iTInfo, [In, MarshalAs(UnmanagedType.U4)] int lcid);
            void GetIDsOfNames([In] ref Guid riid, [In, MarshalAs(UnmanagedType.LPArray)] string[] rgszNames, [In, MarshalAs(UnmanagedType.U4)] int cNames, [In, MarshalAs(UnmanagedType.U4)] int lcid, [Out, MarshalAs(UnmanagedType.LPArray)] int[] rgDispId);
        }
    }
