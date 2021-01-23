    public class ChangeParamInterceptor : IMethodInterceptor
    {
        public int NewValue { get; set; }
        public object Invoke(IMethodInvocation invocation)
        {
            invocation.Arguments[0] = NewValue;
            object rval = invocation.Proceed();
            return rval;
        }
    }
