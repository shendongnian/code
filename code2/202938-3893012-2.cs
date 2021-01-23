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
