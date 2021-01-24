using System;
using System.IO;
using System.Runtime.InteropServices;
namespace Test
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateNamedPipe(string lpName, uint dwOpenMode,
           uint dwPipeMode, uint nMaxInstances, uint nOutBufferSize, uint nInBufferSize,
           uint nDefaultTimeOut, IntPtr lpSecurityAttributes);
        static uint PIPE_ACCESS_DUPLEX = 0x00000003;
        static uint PIPE_ACCESS_INBOUND = 0x00000001;
        static uint PIPE_ACCESS_OUTBOUND = 0x00000002;
        static uint FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000;
        static uint FILE_FLAG_WRITE_THROUGH = 0x80000000;
        static uint FILE_FLAG_OVERLAPPED = 0x40000000;
        static uint WRITE_DAC = 0x00040000;
        static uint WRITE_OWNER = 0x00080000;
        static uint ACCESS_SYSTEM_SECURITY = 0x01000000;
        //One of the following type modes can be specified. The same type mode must be specified for each instance of the pipe.
        static uint PIPE_TYPE_BYTE = 0x00000000;
        static uint PIPE_TYPE_MESSAGE = 0x00000004;
        //One of the following read modes can be specified. Different instances of the same pipe can specify different read modes
        static uint PIPE_READMODE_BYTE = 0x00000000;
        static uint PIPE_READMODE_MESSAGE = 0x00000002;
        //One of the following wait modes can be specified. Different instances of the same pipe can specify different wait modes.
        static uint PIPE_WAIT = 0x00000000;
        static uint PIPE_NOWAIT = 0x00000001;
        //One of the following remote-client modes can be specified. Different instances of the same pipe can specify different remote-client modes.
        static uint PIPE_ACCEPT_REMOTE_CLIENTS = 0x00000000;
        static uint PIPE_REJECT_REMOTE_CLIENTS = 0x00000008;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var name = "test";
            var p = CreateNamedPipe(@"\\.\pipe\" + name, PIPE_ACCESS_OUTBOUND, PIPE_TYPE_MESSAGE | PIPE_WAIT, 255, 0, 4096, 0xffffffff, IntPtr.Zero);
            if (p.ToInt32() == -1)
            {
                throw new Exception("Error creating named pipe " + name + " . Internal error: " + Marshal.GetLastWin32Error().ToString());
            }
            var fs = new FileStream(new Microsoft.Win32.SafeHandles.SafeFileHandle(p, true), FileAccess.Write);
            fs.Close();
        }
    }
}
This appears to be working just fine. Slightly uglier than I'd hoped, but not impossible. Thanks to @David Browne for pointing me in the right direction.
More complete example: https://www.pinvoke.net/default.aspx/kernel32.createnamedpipe
