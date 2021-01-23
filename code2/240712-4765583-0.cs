    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            try {
                IntPtr module = LoadLibraryEx(@"C:\windows\system32\user32.dll", IntPtr.Zero, 2);
                if (module == IntPtr.Zero) throw new Win32Exception();
                if (!EnumResourceNames(module, (IntPtr)3, new EnumResNameProc(ListCallback), IntPtr.Zero))
                    throw new Win32Exception();
            }
            catch (Win32Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    
        static bool ListCallback(IntPtr hModule, IntPtr type, IntPtr name, IntPtr lp) {
            long idorname = (long)name;
            if (idorname >> 32 == 0) Console.WriteLine("#{0}", idorname);
            else Console.WriteLine(Marshal.PtrToStringAnsi(name));
            return true;
        }
    
        public delegate bool EnumResNameProc(IntPtr hModule, IntPtr type, IntPtr name, IntPtr lp);
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static bool EnumResourceNames(IntPtr hModule, IntPtr type, EnumResNameProc lpEnumFunc, IntPtr lParam);
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, int dwFlags);
    }
