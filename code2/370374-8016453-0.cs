    class A 
    {      
       static Dictionary<String, Object> memoizationCache;
       public static bool TryGetMemoizedResult(A instance, out object result)
       {
           return memoizationCache[A.SomeMember]; 
       } 
       public static void AddMemoizedResult(A instance, object result)
       {
           memoizationCache.Add(instance.SomeMember, result); 
       } 
       public object Result {get; private set;}      
       private object RunLongOperation(){/* ... */}   
   
       public A()
       {   
           object result;
           if (TryGetMemoizedResult(this.SomeMember, out result))
           {
                Result = result;
           }
           else 
           {
                Result = RunLongOperation();  
                AddMemoizedResult(this, this.Result); 
           }    
       } 
    } 
