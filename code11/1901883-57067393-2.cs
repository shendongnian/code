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
                int updatedIndex = Interlocked.Add(ref index, 3);
                int localIndex = updatedIndex - 3;
                imageValues[localIndex] = pixel[0];
                imageValues[localIndex + 1] = pixel[1];
                imageValues[localIndex + 2] = pixel[2];
                //index += 3;
            }
        }
    });
