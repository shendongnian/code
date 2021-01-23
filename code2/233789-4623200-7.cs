    static void Main(string[] args)
    {
        var p = Process.GetProcessesByName("ePSXe").FirstOrDefault();
        WriteMem(p, 0x00A66DB9, 99);
    }
