    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Hybridizer.Runtime.CUDAImports;
    
    public class Hello_World
    {
        [EntryPoint]
        public static void Hello()
        {
            Console.Out.Write("Hello from GPU");
        }
    
        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryA", SetLastError = true)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string name);
    
        [DllImport("kernel32.dll", EntryPoint = "FormatMessage", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, [MarshalAs(UnmanagedType.LPArray)] char[] data, uint dwSize, IntPtr args);
    
        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string symbol);
    
        static unsafe string ErrorToString(int er)
        {
            char[] buffer = new char[2048];
            int res = FormatMessage(0x00001000, // FORMAT_MESSAGE_FROM_SYSTEM
                    IntPtr.Zero, er,
                    0x0409, // US language -- in case of issue, replace with 0
                    buffer, 2048, IntPtr.Zero);
            if (res == 0)
                throw new ApplicationException(string.Format("Cannot format message - Error : {0}", res));
            string resstring;
            fixed (char* ptr = &buffer[0])
            {
                resstring = new string(ptr);
            }
            return resstring;
        }
    
        static void Main()
        {
            // Trouble-shooting
    
            // print execution directory
            Console.Out.WriteLine("Current directory : {0}", Environment.CurrentDirectory);
            Console.Out.WriteLine("Size of IntPtr = {0}", Marshal.SizeOf(IntPtr.Zero));
    
            // first, make sure file exists
            string path = @"Troubleshooting_CUDA.dll"; // replace with actual dll name - you can read that on the output of the build
            if (!File.Exists(path))
            {
                Console.Out.WriteLine("Dll could not be found in path, please verify dll is located in the appropriate directory that LoadLibrary may find it");
                Environment.Exit(1);
            }
    
            // make sure it can be loaded -- open DLL in depends to missing troubleshoot dependencies (may be long to load)
            IntPtr lib = LoadLibrary(path);
            if (lib == IntPtr.Zero)
            {
                int code = Marshal.GetLastWin32Error();
                string er = ErrorToString(code);
                Console.Out.WriteLine("Dll could not be loaded : {0}", er);
                Environment.Exit(2);
            }
    
            // finally try to get the proc address -- open DLL in depends to see list of symbols (may be long to load)
            IntPtr procAddress = GetProcAddress(lib, "Hello_Worldx46Hello_ExternCWrapper_CUDA");
            if (procAddress == IntPtr.Zero)
            {
                int code = Marshal.GetLastWin32Error();
                string er = ErrorToString(code);
                Console.Out.WriteLine("Could not find symbol in dll : {0}", er);
                Environment.Exit(3);
            }
    
            cuda.DeviceSynchronize();
            HybRunner runner = HybRunner.Cuda().SetDistrib(1, 2);
            runner.Wrap(new Hello_World()).Hello();
        }
    }
