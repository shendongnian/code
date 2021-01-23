    public IEnumerable<IEnumerable<T>> SplitByCollection<T>(IEnumerable<T> source, 
                                                            IEnumerable<T> delimiter)
    {
        var sourceArray = source.ToArray();
        var delimiterCount = delimiter.Count();
        
        int lastIndex = 0;
    
        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (delimiter.SequenceEqual(sourceArray.Skip(i).Take(delimiterCount)))
            {
                yield return sourceArray.Skip(lastIndex).Take(i - lastIndex);
                i += delimiterCount;
                lastIndex = i;
            }
        }
        
        if (lastIndex < sourceArray.Length)
            yield return sourceArray.Skip(lastIndex);
    }
