    using System.Runtime.InteropServices;  
      
    [DllImport("Kernel32.dll")]  
    static extern long GetTickCount64();  
      
    DateTime osStartTime = DateTime.Now - new TimeSpan(10000 * GetTickCount64());
