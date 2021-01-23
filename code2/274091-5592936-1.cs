    List<List<T>> SplitIntoChunks<T>(IEnumerable<T> originalList, int chunkSize)
    {
        if(originalList.Take(1).Count() == 0)
        {
            return new List<List<T>>();
        }
           
        var chunks = new List<List<T>> {originalList.Take(chunkSize).ToList()};
        chunks.AddRange(SplitIntoChunks(originalList.Skip(chunkSize), chunkSize));
        return chunks;
    }
