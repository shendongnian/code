    public static class Extension
    {
       public static IEnumerable<string> Chunks(this string input, int size)
          // select with index
          => input?.Select((x, i) => i) 
                   // filter by chunk
                   .Where(i => i % size == 0)  
                   // substring out the chunk, or part thereof
                   .Select(i => input.Substring(i, Math.Min(size,input.Length - i)));
    }
