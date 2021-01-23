    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static string ADS_Part = "RunOnceFlag";
            private static uint FILE_FLAG_BACKUP_SEMANTICS = 0x2000000;
            private static uint CREATE_ALWAYS = 2;
            private static uint OPEN_EXISTING = 3;
            private static uint FILE_SHARE_READ = 0x1;
            private static uint GENERIC_READ = 0x80000000;
    
            static void Main(string[] args)
            {
                if (IsFirstEverRun())
                {
                    System.Diagnostics.Trace.WriteLine("First run");
                    SetRunOnce();
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("I've been run at least once!");
                }
            }
            private static bool IsFirstEverRun()
            {
                //Current running EXE (assumes not being loaded from another program)
                string P = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                string ADSFile = P + ":" + ADS_Part;
    
                //Try opening the ADS
                using (var FH = CreateFile(ADSFile, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero))
                {
                    //Return whether its a valid handle or not
                    return FH.IsInvalid;
                }
    
            }
            private static void SetRunOnce()
            {
                //Current running EXE (assumes not being loaded from another program)
                string P = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                string ADSFile = P + ":" + ADS_Part;
    
                //Create the ADS. We could write additional information here such as date/time first run or run counts, too
                using (var FH = CreateFile(ADSFile, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero, CREATE_ALWAYS, FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero)){}
            }
    
    
            [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern Microsoft.Win32.SafeHandles.SafeFileHandle CreateFile(string lpFileName,
                uint dwDesiredAccess,
                uint dwShareMode,
                IntPtr lpSecurityAttributes,
                uint dwCreationDisposition,
                uint dwFlagsAndAttributes,
                IntPtr hTemplateFile);
        }
    }
