    using System;
    using System.Runtime.InteropServices;
    
    class Program
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool GetSystemFileCacheSize(
            ref IntPtr lpMinimumFileCacheSize,
            ref IntPtr lpMaximumFileCacheSize,
            ref IntPtr lpFlags
            );
    
        static void Main(string[] args)
        {
            IntPtr lpMinimumFileCacheSize = IntPtr.Zero;
            IntPtr lpMaximumFileCacheSize = IntPtr.Zero;
            IntPtr lpFlags = IntPtr.Zero;
    
            bool b = GetSystemFileCacheSize(ref lpMinimumFileCacheSize, ref lpMaximumFileCacheSize, ref lpFlags);
    
            Console.WriteLine(b);
            Console.WriteLine(lpMinimumFileCacheSize);
            Console.WriteLine(lpMaximumFileCacheSize);
            Console.WriteLine(lpFlags);
        }
    }
