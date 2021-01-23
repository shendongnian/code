    List<List<T>> SplitIntoChunks<T>(IEnumerable<T> originalList, int chunkSize)
    {
        List<List<T>> result = new List<List<T>>();
        if(originalList.Take(1).Count() == 0)
        {
            return result;
        }
           
        result.Add(originalList.Take(chunkSize).ToList());
        result.AddRange(SplitIntoChunks(originalList.Skip(chunkSize), chunkSize));
        return result;
    }
