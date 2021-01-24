    using System;
    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Sequential)]
    unsafe internal struct Utsname
    {
            public fixed byte sysname[65];
            public fixed byte nodename[65];
            public fixed byte release[65];
            public fixed byte version[65];
            public fixed byte machine[65];
            public fixed byte domainname[65];
    }
    
    public static class Program
    {
            [DllImport("libc.so.6", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int uname(ref Utsname buf);
    
            public static void Main(string[] args)
            {
                    Console.WriteLine(GetUnameRelease());
            }
    
            static unsafe string GetUnameRelease()
            {
                    var buf = new Utsname();
                    uname(ref buf);
                    return Marshal.PtrToStringAnsi((IntPtr)buf.release);
            }
    }
