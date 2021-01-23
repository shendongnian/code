    using System.Runtime.InteropServices;
    using System.Reflection;
    using System.IO;
    ...
            public static void SetupDllDirectory() {
                string path = Assembly.GetEntryAssembly().Location;
                path = Path.Combine(path, IntPtr.Size == 8 ? "x64" : "x86");
                bool ok = SetDllDirectory(path);
                if (!ok) throw new System.ComponentModel.Win32Exception();
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool SetDllDirectory(string path);
