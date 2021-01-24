    private static void ChunkFile(string source, string dest, long chunkSize)
    {
        // Read all lines
        var lines = File.ReadAllLines(source);
        // Calculate number of chunks needed
        // Round up to get correct chunks
        var numberOfChunks = Math.Ceiling((double)lines.Count() / chunkSize);
        // Go through each chunk and write to file
        for (var i = 0; i < numberOfChunks; i++)
        {
            # Skip lines chunks we've already seen, and take the next chunk
            var chunk = lines.Skip(i * (int)chunkSize).Take((int)chunkSize);
            # Write chunk to destination path
            File.WriteAllLines(Path.Combine(dest, $"File{i + 1}.txt"), chunk);
        }
    }
