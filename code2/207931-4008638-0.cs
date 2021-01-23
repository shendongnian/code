    using System;
    using System.Runtime.InteropServices;
    
    public class MainClass
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
           out ulong lpFreeBytesAvailable,
           out ulong lpTotalNumberOfBytes,
           out ulong lpTotalNumberOfFreeBytes);
        public static void Main()
        {
            ulong freeBytesAvail;
            ulong totalNumOfBytes;
            ulong totalNumOfFreeBytes;
    
            if (!GetDiskFreeSpaceEx("C:\\", out freeBytesAvail, out totalNumOfBytes, out totalNumOfFreeBytes))
            {
                Console.Error.WriteLine("Error occurred: {0}",
                    Marshal.GetExceptionForHR(Marshal.GetLastWin32Error()).Message);
            }
            else
            {
                Console.WriteLine("Free disk space:");
                Console.WriteLine("    Available bytes : {0}", freeBytesAvail);
                Console.WriteLine("    Total # of bytes: {0}", totalNumOfBytes);
                Console.WriteLine("    Total free bytes: {0}", totalNumOfFreeBytes);
            }
        }
    }
