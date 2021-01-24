    Parallel.ForEach(Partitioner.Create(0, bytes.Length), range =>
    {
        for (int i = range.Item1; i < range.Item2; i++)
        {
            bytes[i] += bytes2[i];
        }
    });
