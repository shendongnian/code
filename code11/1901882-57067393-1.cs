    ParallelOptions options = new ParallelOptions()
    {
        MaxDegreeOfParallelism = Math.Max(1, Environment.ProcessorCount - 1)
    };
    Parallel.ForEach(Partitioner.Create(0, temps.Length), options, range =>
    {
        for (int item = range.Item1; item < range.Item2; item++)
        {
            byte[] pixel = new byte[3];
            if (Lookup.TryGetValue(item, out pixel))
            {
                imageValues[index] = pixel[0];
                imageValues[index + 1] = pixel[1];
                imageValues[index + 2] = pixel[2];
                //index += 3;
                Interlocked.Add(ref index, 3);
            }
        }
    });
