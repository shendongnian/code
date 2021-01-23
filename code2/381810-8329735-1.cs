    interface IMemoizer
    {
       bool IsValid(); //Is the cache valid, or stale, etc. 
       bool TryLookup(params object[] args, out object result); 
     
       void StoreResult(params object[] args, object result); 
    }
    interface IMemoizable
    {
       IMemoizer GetMemoizer(); 
    }
    static IMemoizableExtensions
    {
       Func<Object[], R> Memoize<R>(this IMemoizable src, string method)
       {
          IMemoizer memoizer = src.GetMemoizer(); 
          MethodInfo target = src.GetType().GetMethod(method); 
          return new Func<Object[], R>(args =>
          {
             object result;
             if (memoizer.TryLookup(args, result) && src.IsValid)
             {
                return (R)result; 
             }
             else
             {
                R result = (R)target.Invoke(src, args); 
                memoizer.StoreResult(args, result); 
                return result; 
             }
          }); 
       }   
    }
