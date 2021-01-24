    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    namespace ConsoleApp
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
             public struct PROCESSENTRY32W
            {
                public uint dwSize;
                public uint cntUsage;
                public uint th32ProcessID;
                public IntPtr th32DefaultHeapID;
                public uint th32ModuleID;
                public uint cntThreads;
                public uint th32ParentProcessID;
                public int pcPriClassBase;
                public uint dwFlags;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szExeFile;
            };
            [DllImport("kernel32.dll", EntryPoint = "CreateToolhelp32Snapshot")]
            public static extern IntPtr CreateToolhelp32SnapshotRtlMoveMemory(UInt32 dwFlagsdes, UInt32 th32ProcessID);
    
            [DllImport("kernel32", EntryPoint = "Process32First", SetLastError = true, CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32W lppe);
    
            [DllImport("kernel32", EntryPoint = "Process32Next", CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32W lppe);
    
            [DllImport("kernel32", EntryPoint = "CloseHandle")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CloseHandle(IntPtr handle);
            public static Dictionary<int, Process> get_process_list()
            {
                //Dictionary<string, Process> returnable_processes_ = new Dictionary<string, Process>();
                Dictionary<int, Process> returnable_processes_ = new Dictionary<int, Process>();
                IntPtr HANLDE_Processes = CreateToolhelp32SnapshotRtlMoveMemory(2, 0);
    
                PROCESSENTRY32W p32Iw = new PROCESSENTRY32W();
                int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(PROCESSENTRY32W));
                p32Iw.dwSize = Convert.ToUInt32(size);
                //IntPtr p32IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(p32Iw));
                //Marshal.StructureToPtr(p32Iw, p32IntPtr, false);
                bool blFirstProcess = Process32First(HANLDE_Processes, ref p32Iw); // returns false no matter what?
                int x = Marshal.GetLastWin32Error();
    
                if (blFirstProcess)
                {
    
                    do
                    {
                        int PID = (int)p32Iw.th32ProcessID;
                        returnable_processes_.Add(PID, new Process());
                        Console.WriteLine(p32Iw.szExeFile);
    
                    }
                    while (Process32Next(HANLDE_Processes, ref p32Iw));
                }
                return returnable_processes_;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                get_process_list();
                Console.ReadKey();
            }
        }
    }
