    byte[] bytes = new byte[]
    {
        0xff, 0xff, 0xff, 0xff, 0x00, 0x00, 0x31, 0x32, 0x33, 0x34, 0xff, 0x2a, 0x00
    };
    var s = Encoding.Default.GetString(bytes);
    Console.WriteLine(bytes.Length);
    Console.WriteLine(s.Length);
    foreach (var c in s)
    {
        Console.Write("0x{0:X2}, ", (int)c);
    }
    Console.WriteLine();
