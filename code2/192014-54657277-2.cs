    using System;
    using System.Text;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    internal static class Native
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static bool GetFileInformationByHandleEx(IntPtr  hFile,
                                                               int     FileInformationClass,
                                                               IntPtr  lpFileInformation,
                                                               uint    dwBufferSize);
    
        public struct FILE_STANDARD_INFO
        {
            public long AllocationSize;
            public long EndOfFile;
            public uint NumberOfLinks;
            public byte DeletePending;
            public byte Directory;
        }
        public const int FileStandardInfo = 1;
    }
    
    internal static class Program
    {
        public static bool IsDeletePending(FileStream fs)
        {
            IntPtr buf = Marshal.AllocHGlobal(4096);
            try
            {
                IntPtr handle = fs.SafeFileHandle.DangerousGetHandle();
                if (!Native.GetFileInformationByHandleEx(handle,
                                                         Native.FileStandardInfo,
                                                         buf,
                                                         4096))
                {
                    Exception ex = new Exception("GetFileInformationByHandleEx() failed");
                    ex.Data["error"] = Marshal.GetLastWin32Error();
                    throw ex;
                }
                else
                {
                    Native.FILE_STANDARD_INFO info = Marshal.PtrToStructure<Native.FILE_STANDARD_INFO>(buf);
                    return info.DeletePending != 0;
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buf);
            }
        }
    
        public static int Main(string[] args)
        {
            TimeSpan MAX_WAIT_TIME = TimeSpan.FromSeconds(10);
    
            if (args.Length == 0)
            {
                args = new string[] { "deleteme.txt" };
            }
    
            for (int i = 0; i < args.Length; ++i)
            {
                string filename = args[i];
                FileStream fs = null;
    
                try
                {
                    fs = File.Open(filename,
                                   FileMode.CreateNew,
                                   FileAccess.Write,
                                   FileShare.ReadWrite | FileShare.Delete);
    
                    byte[] buf = new byte[4096];
                    UTF8Encoding utf8 = new UTF8Encoding(false);
    
                    string text = "hello world!\r\n";
                    int written = utf8.GetBytes(text, 0, text.Length, buf, 0);
                    fs.Write(buf, 0, written);
                    fs.Flush();
    
                    Console.WriteLine("{0}: created and wrote line", filename);
    
                    DateTime t0 = DateTime.UtcNow;
                    for (;;)
                    {
                        Thread.Sleep(16);
                        if (IsDeletePending(fs))
                        {
                            Console.WriteLine("{0}: detected pending delete", filename);
                            break;
                        }
                        if (DateTime.UtcNow - t0 > MAX_WAIT_TIME)
                        {
                            Console.WriteLine("{0}: timeout reached with no delete", filename);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}: {1}", filename, ex.Message);
                }
                finally
                {
                    if (fs != null)
                    {
                        Console.WriteLine("{0}: closing", filename);
                        fs.Dispose();
                    }
                }
            }
            return 0;
        }
    }
