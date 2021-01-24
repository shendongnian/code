    public int NumSetBits()
    {
        int count = 0;
        var partitioner = Partitioner.Create(0, bits.Length);
        Parallel.ForEach(partitioner, (range, loopState) =>
        {
            int subtotal = 0;
            for (int i = range.Item1; i < range.Item2; ++i)
            {
                subtotal += hammingWeight(bits[i]);
            }
            Interlocked.Add(ref count, subtotal);
        });
        return count;
    }
