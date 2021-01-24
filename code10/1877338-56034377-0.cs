    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        const int PROCESS_WM_READ = 0x0010;
        static void Main(string[] args)
        {
            Process process = Process.GetProcessById(13568);
            IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
            // Get the process start information
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("BingDict");
            // Assign 'StartInfo' of notepad to 'StartInfo' of 'process' object.
            process.StartInfo = myProcessStartInfo;
            //process.Start();
            System.Threading.Thread.Sleep(1000);
            ProcessModule myProcessModule;
            // Get all the modules associated with the process
            ProcessModuleCollection myProcessModuleCollection = process.Modules;
            Console.WriteLine("Base addresses of the modules associated are:");
            // Display the 'BaseAddress' of each of the modules.
            for (int i = 0; i < myProcessModuleCollection.Count; i++)
            {
                myProcessModule = myProcessModuleCollection[i];
                Console.WriteLine(myProcessModule.ModuleName + " : "
                    + myProcessModule.BaseAddress);
            }
            // Get the main module associated with the process
            myProcessModule = process.MainModule;
            // Display the 'BaseAddress' of the main module.
            Console.WriteLine("The process's main module's base address is: {0:X4}",
                (int)myProcessModule.BaseAddress);
            var ptr = (int)myProcessModule.BaseAddress;
            for (int i = 1; i < 129; i++)
            {
                int bytesRead = 0;
                byte[] buffer = new byte[1];
                try
                {
                    if (ReadProcessMemory((int)processHandle, ptr, buffer, buffer.Length, ref bytesRead))
                    {
                        Console.WriteLine(buffer[0]);
                    }                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
