    public class NewMem
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
    
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead); 
    
        public Process Process { get; set; }
    
        public static IntPtr GetModuleBaseAddress(Process proc, string modName)
        {
            IntPtr addr = IntPtr.Zero;
    
            foreach (ProcessModule m in proc.Modules)
            {
                if (m.ModuleName == modName)
                {
                    addr = m.BaseAddress;
                    break;
                }
            }
            return addr;
        }
    
        public static IntPtr FindDMAAddy(IntPtr hProc, IntPtr ptr, int[] offsets)
        {
            var buffer = new byte[IntPtr.Size];
            foreach (int i in offsets)
            {
                ReadProcessMemory(hProc, ptr, buffer, buffer.Length, out var read);
    
                ptr = (IntPtr.Size == 4)
                ? IntPtr.Add(new IntPtr(BitConverter.ToInt32(buffer, 0)), i)
                : ptr = IntPtr.Add(new IntPtr(BitConverter.ToInt64(buffer, 0)), i);
            }
            return ptr;
        }
    
        public string ReadStringASCII(IntPtr address)
        {
            var myString = "";
    
            for (int i = 1; i < 50; i++)
            {
                var bytes = ReadMemory(address, i);
                if (bytes[(i-1)] == 0)
                {                    
                    return myString;
                }
                myString = Encoding.ASCII.GetString(bytes);
            }
    
            return myString;
        }
    
        public byte[] ReadMemory(IntPtr address, int size)
        {
            var buffer = new byte[size];
            var bytesRead = 0;
    
            ReadProcessMemory((int)Process.Handle, (int)address, buffer, buffer.Length, ref bytesRead);
    
            return buffer;
    
        }
    }
