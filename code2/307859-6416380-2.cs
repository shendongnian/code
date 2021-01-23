    public IEnumerable<IEnumerable<T>> SplitByCollection<T>(IEnumerable<T> source, IEnumerable<T> delimiter)
    {
        var sourceArray = source.ToArray();
        var delimiterCount = delimiter.Count();
        var result = new List<IEnumerable<T>>();
        
        int lastIndex = 0;
    
        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (delimiter.SequenceEqual(sourceArray.Skip(i).Take(delimiterCount)))
            {
                result.Add(sourceArray.Skip(lastIndex).Take(i-lastIndex));
                i += delimiterCount;
                lastIndex = i;
            }
        }
        
        result.Add(sourceArray.Skip(lastIndex));
        
        return result;
    }
