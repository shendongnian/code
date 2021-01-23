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
       Func<R> Memoize<R>(this IMemoizable src, Delegate target, object[] args)
       {
          IMemoizer memoizer = src.GetMemoizer(); 
          return delegate
          {
             object result;
             if (memoizer.TryLookup(args, result))
             {
                return (R)result; 
             }
             else
             {
                R result = (R)target.DynamicInvoke(args); 
                memoizer.StoreResult(args, result); 
                return result; 
             }
          }
       }   
    }
