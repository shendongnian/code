    [DllImport(@"testlib.dll")]
    static extern void GetInfo(int Memadr, int Infolen, byte[] result);
    static void Main(string[] args)
    {
        byte[] result = new byte[256];
        GetInfo(0, result.Length, result);
        foreach (byte b in result)
            Console.WriteLine(b);
    }
