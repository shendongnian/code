    public static void ProcessInChunks(string inputFilename,
        string delimiter, Action<IEnumerable<string>> processChunk)
    {
        using (var enumerator = File.ReadLines(inputFilename).GetEnumerator())
        {
            if (!enumerator.MoveNext())
                // The file is empty.
                return;
            var firstLine = enumerator.Current;
            if (firstLine != delimiter)
                throw new InvalidOperationException(
                    "Expected the first line to be a delimiter.");
        
            List<string> currentChunk = new List<string>();
        
            while (enumerator.MoveNext())
            {
                if (enumerator.Current == delimiter)
                {
                    processChunk(currentChunk);
                    currentChunk = new List<string>();
                }
                else
                    currentChunk.Add(enumerator.Current);
            }
            processChunk(currentChunk);
        }
