    class A 
    {      
       static Dictionary<String, Object> memoizationCache;
       public static bool TryGetMemoizedResult(A instance, out object result)
       {
           // do the checking etc. 
           result = memoizationCache[instance.SomeMember]; 
       } 
       public static void AddMemoizedResult(A instance, object result)
       {
           memoizationCache.Add(instance.SomeMember, result); 
       } 
       public object Result {get; private set;}   
       public string SomeMember { get; private set; }   
       private object RunLongOperation(){/* ... */}   
   
       public A()
       {   
           object result;
           if (TryGetMemoizedResult(this, out result))
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
