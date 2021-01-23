    using System;
    using System.Runtime.InteropServices;
    using RGiesecke.DllExport;
    namespace UDKManagedTestDLL
    {
        struct TestStruct
        {
            public int Value;
        }
    
        public static class UnmanagedExports
        {
            // Get string from C#
            // returned strings are copied by UnrealScript interop system so one
            // shouldn't worry about allocation\deallocation problem
            [DllExport("GetString", CallingConvention = CallingConvention.StdCall]
            [return: MarshalAs(UnmanagedType.LPWStr)]
            static string GetString()
            {
                return "Hello UnrealScript from C#!";
            }
            //This function takes int, squares it and return a structure
            [DllExport("GetStructure", CallingConvention = CallingConvention.StdCall]
            static TestStructure GetStructure(int x)
            {
                 return new TestStructure{Value=x*x};
            }
            //This function fills UnrealScript string
            //(!) warning (!) the string should be initialized (memory allocated) in UnrealScript
            // see example of usage below            
            [DllExport("FillString", CallingConvention = CallingConvention.StdCall]
            static void FillString([MarshalAs(UnmanagedType.LPWStr)] StringBuilder str)
            {
                str.Clear();    //set position to the beginning of the string
                str.Append("ha ha ha");
            }
        }
    }
