      [Flags]
      private enum ProcessAccessFlags : uint
      {
          QueryLimitedInformation = 0x00001000
      }
  
      private static extern bool QueryFullProcessImageName(
            [In] IntPtr hProcess,
            [In] int dwFlags,
            [Out] StringBuilder lpExeName,
            ref int lpdwSize);
        [DllImport("kernel32.dll", SetLastError = true)]
      private static extern IntPtr OpenProcess(
         ProcessAccessFlags processAccess,
         bool bInheritHandle,
         int processId);
    String GetProcessFilename(Process p)
    { 
     int capacity = 2000;
     StringBuilder builder = new StringBuilder(capacity);
     IntPtr ptr = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, p.Id);
     if (!QueryFullProcessImageName(ptr, 0, builder, ref capacity))
     {
        return String.Empty;
     }
     return builder.ToString();
    }
