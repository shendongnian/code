    static void Main(string[] args)
    {
        byte[] pattern = new byte[] { 3, 2, 1 };
        byte[] data = new byte[] { 1, 2, 3, 4, 5, 4, 3, 2, 1, 2, 3, 4, 5, 4, 3, 2, 1 };
        foreach (long offset in FindPattern(pattern, data))
        {
            Console.WriteLine(offset);
        }
        Console.ReadLine();
    }
    public static IEnumerable<long> FindPattern(byte[] pattern, byte[] data)
    {
        Queue<byte> queue = new Queue<byte>(pattern.Length);
        using (MemoryStream input = new MemoryStream(data))
        using (BinaryReader reader = new BinaryReader(input))
        {
            byte[] buffer = new byte[1];
            while (1 == reader.Read(buffer, 0, 1))
            {
                if (queue.Count == pattern.Length)
                {
                    queue.Dequeue();
                }
                queue.Enqueue(buffer[0]);
                if (Matches(queue, pattern))
                {
                    // The input is positioned after the last read byte, which
                    // completed the pattern.
                    yield return input.Position;
                }
            }
        }
    }
    private static bool Matches(Queue<byte> data, byte[] pattern)
    {
        return data.SequenceEqual(pattern);
    }
