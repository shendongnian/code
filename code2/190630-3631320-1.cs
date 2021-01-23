    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    class Program {
        unsafe static void Main(string[] args) {
            IntPtr hMod = LoadLibrary("cpptemp10.dll");
            if (hMod == IntPtr.Zero) throw new Win32Exception();
            IntPtr export = GetProcAddress(hMod, "some_callback");
            if (export == IntPtr.Zero) throw new Win32Exception();
            IntPtr callback = Marshal.ReadIntPtr(export);
            some_callback dlg = (some_callback)Marshal.GetDelegateForFunctionPointer(callback, typeof(some_callback));
            int retval = dlg(null, null);
            Console.WriteLine(retval);
            Console.ReadLine();
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        unsafe delegate int some_callback(int* arg1, uint* arg2);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string path);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hMod, string name);
    
    }
