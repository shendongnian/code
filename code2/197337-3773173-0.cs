    static unsafe void DoIt(int* ptr)
    {
        Console.WriteLine(ptr[0]);
        Console.WriteLine(ptr[1]);
        Console.WriteLine(ptr[2]);
    }
    static unsafe void Main()
    {
        var bytes = new byte[1024];
        new Random().NextBytes(bytes);
        fixed (byte* p = bytes)
        {
            for (int i = 0; i < bytes.Length; i += sizeof(int))
            {
                DoIt((int*)(p + i));
            }
        }
        Console.ReadKey();
    }
