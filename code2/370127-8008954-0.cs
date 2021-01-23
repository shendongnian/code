    // {0, ..., 100}
    byte[] data = Enumerable.Range(0, 101).Select(i => (byte)i).ToArray();
    Write(data, 0, 3);
    Write(data, 3, 3);
    ...
    static void Write(byte[] buffer, int offset, int count)
    {
        for(int i = offset ; i < offset + count; i++)
            Console.WriteLine(buffer[i]);
        Console.WriteLine();
    }
