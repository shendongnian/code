    public SomeClass MyMethod(MyClass whatever) 
    {
        if(whatever == null)
        {
            SomeClass result = Cache["MyMethodCache"] as SomeClass;
            if(result != null)
            return result;
        }
    
    
        //do something...
    
        if(whatever == null)
        {
             Cache.Add("MyMethodCache",something, ... ); //duration, expiration policy, etc.
        }
    
        return something; 
    } 
