    // Note: block size must be a factor of 1MB to avoid rounding errors :)
    const int blockSize = 1024 * 8;
    const int blocksPerMb = (1024 * 1024) / blockSize;
    byte[] data = new byte[blockSize];
    Random rng = new Random();
    using (FileStream stream = File.OpenWrite(fileName))
    {
        // There 
        for (int i = 0; i < sizeInMb * blocksPerMb; i++)
        {
            rng.NextBytes(data);
            stream.Write(data, 0, data.Length);
        }
    }
