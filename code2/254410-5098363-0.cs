    public static IQueryable<T> Trace<T> (this IQueryable<T> input, 
                                       string format, 
                                       params object[] data)
    {
      if(input == null)
        throw new ArgumentNullException("input");
      
      Trace.WriteLine(format, data);
      
      return input;
    }
