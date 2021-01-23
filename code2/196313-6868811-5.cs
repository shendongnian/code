    public static long GetFileSizeOnDisk(string file)
    {
        FileInfo info = new FileInfo(file);
        uint clusterSize;
        using(var searcher = new ManagementObjectSearcher("select BlockSize,NumberOfBlocks from Win32_Volume WHERE DriveLetter = '" + info.Directory.Root.FullName.TrimEnd('\\') + "'") {
            clusterSize = (uint)(((ManagementObject)(searcher.Get().First()))["BlockSize"]);
        }
        uint hosize;
        uint losize = GetCompressedFileSizeW(file, out hosize);
        long size;
        size = (long)hosize << 32 | losize;
        return ((size + clusterSize - 1) / clusterSize) * clusterSize;
    }
    [DllImport("kernel32.dll")]
    static extern uint GetCompressedFileSizeW(
       [In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
       [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);
