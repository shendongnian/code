    private static void ChunkFile(string sourceFile, string destDirectory, int chunkSize)
    {
        // Read all lines
        var lines = File.ReadLines(sourceFile)
        // Calculate number of chunks needed
        // Round up to get correct chunks
        var numberOfChunks = (int)Math.Ceiling((double)lines.Count() / chunkSize);
        // Go through each chunk and write to file
        for (var i = 0; i < numberOfChunks; i++)
        {
            // Skip lines chunks we've already seen, and take the next chunk
            var chunk = lines.Skip(i * chunkSize).Take(chunkSize);
            // Write chunk to destination path
            File.WriteAllLines(Path.Combine(destDirectory, $"File{i + 1}.txt"), chunk);
        }
    }
