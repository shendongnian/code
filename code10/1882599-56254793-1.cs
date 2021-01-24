    using System;
    using System.Runtime.InteropServices;
    
    namespace HardInfoRetriever
    {
        class DiskInfoRetreiver
        {
    
            [DllImport("C:\\Users\\User1\\Documents\\Visual Studio 2017\\Projects\\HardInfoRetriever\\Debug\\JNIDiskInfoDll.dll",
                EntryPoint = "getSerial", CallingConvention = CallingConvention.Cdecl,
                BestFitMapping = false, ThrowOnUnmappableChar = true, CharSet = CharSet.Ansi)]
            //[return: MarshalAs(UnmanagedType.LPTStr)]
            public static extern int getSerial([MarshalAs(UnmanagedType.LPTStr)] string _driveletter_, [MarshalAs(UnmanagedType.BStr)] out string serial);
            public static String getSerialNumber(string letter)
            {
                try
                {
                    string serial;
                    int result =  getSerial(letter, out serial);
                    if (result == 0)
                    {
                        return serial;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
   
