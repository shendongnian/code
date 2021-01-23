    uses System.Reflection
    
    ....
    
    public void ExecuteMethod(object thing, string method)
    {
       Type type = thing.GetType(); //gets the runtime type of the object
       MethodInfo mi = type.GetMethod(method); // null if method not found
       mi.Invoke(thing, null); //invokes the method on the "thing" object,
                               //passing null arguments, and returns the result
    }
