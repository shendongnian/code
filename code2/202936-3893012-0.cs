    int f() 
    {
        // no need to try-catch any more, here or anywhere else...
        int i = process();
        return i;
    }
    // you only have to define this class once and hook it up to your app via 
    // unity interception.  Once you hook it up, it will handle all exceptions
    // thrown in your app.
    // The code would look more or less like this (fundamentally)
    public class MyCallHandler : ICallHandler, IDisposable
    {
        public IMethodReturn Invoke(IMethodInvocation input, 
            GetNextHandlerDelegate getNext)
        {
            // call the method
            var methodReturn = getNext().Invoke(input, getNext);
            // check if an exception was raised.
            if (methodReturn.Exception != null)
            {
                // take the original exception and raise a new (correct) one...
                CreateSpecificFault(methodReturn.Exception);
                // set the original exception to null to avoid throwing yet another
                // exception
                methodReturn.Exception = null;
            }
  
            // complete the invoke...
            return methodReturn;
        }
    }
