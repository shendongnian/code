csharp
public class FileCopier
{
	public virtual void CopyFile(string filePath, string destPath)
	{
		// do things here
	}
}
public class ImpersonationInterceptor : IInterceptor
{
	public void Intercept(IInvocation invocation)
	{
		using (var I = new Impersonator("user", ".", "password"))
		{			
			invocation.Proceed();
		}		
	}
}
public class LoggingInterceptor : IInterceptor
{
	public void Intercept(IInvocation invocation)
	{
		try
		{
			invocation.Proceed();
		}		
		catch (Exception e)
		{
			Log(e.Message);
		}
	}
}
public class CustomProxyGenerationHook : IProxyGenerationHook
{
	public void MethodsInspected() {}
	public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo) {}
	public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
	{
		// decide whether you need to intercept your method here		
		return true;
	}
}
void Main()
{
	var generator = new ProxyGenerator();
	var options = new ProxyGenerationOptions(new CustomProxyGenerationHook());
	var fileCopierProxy = generator.CreateClassProxy(typeof(FileCopier),
				options
				new IInterceptor[] { // specify list of interceptors 
					new ImpersonationInterceptor(), 
					new LoggingInterceptor() 
					}
				) as FileCopier;
	fileCopierProxy.CopyFile("src", "dest");
}
Even if you've got a ton of classes and modifying them all by hand is not feasible, you can still work around it by opting for yet another technique called assembly weaving. [Project Fody][3] is a good starting point, and this particular problem is best solved with [Virtuosity][4] plugin - it basically rewrites your assembly on build to mark all methods virtual so you don't have to do it yourself.
  [1]: https://en.wikipedia.org/wiki/Aspect-oriented_programming
  [2]: https://www.castleproject.org/projects/dynamicproxy/
  [3]: https://github.com/Fody/Fody
  [4]: https://github.com/Fody/Virtuosity
