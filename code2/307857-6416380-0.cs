    public IEnumerable<IEnumerable<T>> SplitByCollection<T>(IEnumerable<T> source, IEnumerable<T> delimiter)
    {
        var result = new List<IEnumerable<T>>();
        
        int lastIndex = 0;
    
        for (int i = 0; i < source.Count(); i++)
        {
            if (delimiter.SequenceEqual(source.Skip(i).Take(delimiter.Count())))
            {
                result.Add(source.Skip(lastIndex).Take(i-lastIndex));
                i += delimiter.Count();
                lastIndex = i;
            }
        }
        
        result.Add(source.Skip(lastIndex));
        
        return result;
    }
