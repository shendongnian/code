    public static bool In<T>(this T item, IEnumerable<T> sequence)
    {
       if(sequence == null)
          throw new ArgumentNullException("sequence");
       
       return sequence.Contains(item);    
    }
