    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using RGiesecke.DllExport;
    
    namespace ClassLibrary3
    {
        [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
        public class Class1
        {
            public string Text
            {
                [return: MarshalAs(UnmanagedType.BStr)]
                get;
                [param: MarshalAs(UnmanagedType.BStr)]
                set;
            }
    
            [return: MarshalAs(UnmanagedType.BStr)]
            public string TestMethod()
            {
                return Text + "...";
            }
        }
    
        static class UnmanagedExports
        {
            [DllExport]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            static Object CreateDotNetObject(String text)
            {
                return new Class1 { Text = text };
            }
        }
    }
