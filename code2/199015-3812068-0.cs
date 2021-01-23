    public static T WhenNull<T>(this T source, Func<T> nullFunc)
    {
       if (source != null)
       {
          return source;
       } 
    
       if (nullFunc == null)
       {
           throw new ArgumentNullException("nullFunc");
       }
    
       return nullFunc();
    }
