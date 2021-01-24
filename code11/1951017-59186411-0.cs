    public class ExecuteAfterMethod : Interceptor
    {
		protected override void ExecuteAfter(Castle.DynamicProxy.IInvocation invocation)
		{
			invocation.ReturnValue = (invocation.ReturnValue as string[]).Reverse().ToArray();
		}
    }
