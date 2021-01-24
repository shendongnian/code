    public class ExecuteAfterMethod : Interceptor
    {
		protected override void ExecuteAfter(Castle.DynamicProxy.IInvocation invocation)
		{
			var stringArray = (invocation.ReturnValue as string[]).Reverse().ToArray(); // here will have the object typed as String[], so printing it should be no problem.
        foreach(var item in stringArray) {
             Console.WriteLine(item);
        }
        invocation.ReturnValue = stringArray; // and finally we reassign the result
		}
    }
