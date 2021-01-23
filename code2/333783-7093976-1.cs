    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            const int FILE_ATTRIBUTE_SYSTEM = 0x4;
            const int FILE_FLAG_SEQUENTIAL_SCAN = 0x8;
    
            [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern SafeFileHandle CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, int flags, IntPtr template);
    
            [STAThread]
            static void Main()
            {
                using (SafeFileHandle device = CreateFile(@"\\.\E:", FileAccess.Read, FileShare.Write | FileShare.Read | FileShare.Delete, IntPtr.Zero, FileMode.Open, FILE_ATTRIBUTE_SYSTEM | FILE_FLAG_SEQUENTIAL_SCAN, IntPtr.Zero))
                {
                    if (device.IsInvalid)
                    {
                        throw new IOException("Unable to access drive. Win32 Error Code " + Marshal.GetLastWin32Error());
                    }
                    using (FileStream dest = File.Open("TempFile.bin", FileMode.Create))
                    {
                        using (FileStream src = new FileStream(device, FileAccess.Read))
                        {
                            src.CopyTo(dest);
                        }
                    }
                }
            }
        }
    }
