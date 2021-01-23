    public static void ProcessInChunks(string inputFilename,
        string delimiter, Action<IEnumerable<string>> processChunk)
    {
        var lines = File.ReadAllLines(inputFilename);
    
        if (lines[0] != delimiter)
            throw new InvalidOperationException("Expected the first line to be a start line.");
    
        List<string> currentChunk = new List<string>();
    
        foreach (var line in lines.Skip(1))
        {
            if (line == delimiter)
            {
                processChunk(currentChunk);
                currentChunk = new List<string>();
            }
            else
                currentChunk.Add(line);
        }
        processChunk(currentChunk);
    }
