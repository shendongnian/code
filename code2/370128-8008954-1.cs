    fixed(byte* ptr = data)
    {
        Write(ptr, 3);
        Write(ptr + 3, 3);
    }
    ...
    static unsafe void Write(byte* ptr, int count)
    {
        for (int i = 0; i < count; i++)
            Console.WriteLine(ptr[i]);
        Console.WriteLine();
    }
