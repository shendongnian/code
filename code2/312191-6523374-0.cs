    byte[, ,] src = new byte[10, 10, 3];
    byte[,] dest = new byte[100, 3];
    List<byte> srcList = new List<byte>();
    Random rnd = new Random();
    for (int i = 0; i < 10; ++i)
    {
        for (int j = 0; j < 10; ++j)
        {
            for (int k = 0; k < 3; ++k)
            {
                byte b = (byte)rnd.Next();
                src[i, j, k] = b;
                srcList.Add(b);
            }
        }
    }
    Buffer.BlockCopy(src, 0, dest, 0, 300);
    List<byte> destList = new List<byte>();
    for (int i = 0; i < 100; ++i)
    {
        for (int j = 0; j < 3; ++j)
        {
            destList.Add(dest[i, j]);
        }
    }
    // See if they're in the same order
    for (int i = 0; i < srcList.Count; ++i)
    {
        Console.WriteLine("{0,3:N0} - {1,3:N0}", srcList[i], destList[i]);
        if (srcList[i] != destList[i])
        {
            Console.WriteLine("ERROR!");
        }
    }
