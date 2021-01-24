    static void Main(string[] args)
    {
        byte[] byteArr = new byte[] { 248, 255, 247, 254 };
        Console.WriteLine(byteArr[2]);
        f(byteArr);
        Console.WriteLine(byteArr[2]);
    }
    private static void f(byte[] byteArr)
    {
        Span<short> shArr = MemoryMarshal.Cast<byte, short>(byteArr);
        shArr[1] = 42;
    }   
