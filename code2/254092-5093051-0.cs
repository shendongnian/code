    public static IEnumerable<IList<T>> GetOverlappingChunks<T>(
        this IEnumerable<T> sequence, int chunkSize)
    {
        List<T> chunk = new List<T>(chunkSize);
    
        foreach (var elt in sequence)
        {
            chunk.Add(elt);
    
            if (chunk.Count > chunkSize)
                chunk.RemoveAt(0);
    
            if (chunk.Count == chunkSize)
                yield return chunk.ToArray();
        }
    }
    
    // ...
    
    var result = players.OrderByDescending(p => p.Score)
                 .GetOverlappingChunks(3)
                 .Where(x => x[1].Id == 1);
