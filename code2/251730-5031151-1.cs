    public class MyCaller
    {
       public OtherClass otherClassInstance;
    
       public void CallbackMethod() {...}
    
       public void UsesTheCallback()
       {
          //The callback method itself is being passed
          otherClassInstance.MethodWithCallback(CallbackMethod);
       }
    }
    
    public class OtherClass
    {
       public delegate void CallbackDelegate()
       public void MethodWithCallback(CallbackDelegate callback)
       {
          //do some work, then...
          callback(); //invoke the delegate, "calling back" to MyCaller.CallbackMethod()
       }
    }
