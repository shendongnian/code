    public class ChangeParamInterceptor : IMethodInterceptor
    {
        public int NewValue { get; set; }  // set in spring cofig
        public object Invoke(IMethodInvocation invocation)
        {
            invocation.Arguments[0] = NewValue; // change the argument
            object rval = invocation.Proceed();
            return rval;
        }
    }
