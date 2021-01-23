    interface IMemoizer<T, R>
    {
       bool IsValid(T args); //Is the cache valid, or stale, etc. 
       bool TryLookup(T args, out R result);    
       void StoreResult(T args, R result); 
    }
    static IMemoizerExtensions
    {
       Func<T, R> Memoizing<T, R>(this IMemoizer src, Func<T, R> method)
       {
          return new Func<T, R>(args =>
          {
             R result;
             if (src.TryLookup(args, result) && src.IsValid(args))
             {
                return result; 
             }
             else
             {
                result = method.Invoke(args); 
                memoizer.StoreResult(args, result); 
                return result; 
             }
          }); 
       }   
    }
