csharp
//suppose we've got a class:
public class A
{
	public string Test {get;set;}
	public virtual string ReturnTest() => Test;
}
//and some code below:
void Main()
{
	var config = new A() {
		Test = "TEST"
	} ;
	
	var mockedConfig = new Mock<A>(); // first we run a stock standard mock
	mockedConfig.CallBase = true; // we will enable CallBase just to point out that it makes no difference	
	var o = mockedConfig.Object;
	Console.WriteLine(o.ReturnTest()); // this will be null because Test has not been initialised from constructor
	mockedConfig.Setup(c => c.ReturnTest()).Returns("mocked"); // of course if you set up your mocks - you will get the value
	Console.WriteLine(o.ReturnTest()); // this will be "mocked" now, no surprises
}
now, knowing that `Moq` internally leverages [Castle DynamicProxy][2] and it actually allows us to generate proxies for instances (they call it [Class proxy with target][3]). Therefore the question is - how do we get `Moq` to make one for us.
It seems there's no such option out of the box, and simply injecting the override didn't quite go well as there's not much inversion of control inside the library and most of the types and properties are marked as `internal`, making inheritance virtually impossible.
`Castle Proxy` is however much more user firendly and has quite a few methods exposed and available for overriding. So let us define a `ProxyGenerator` class that would take the method `Moq` calls and add required functionality to it (just compare [`CreateClassProxyWithTarget`][4] and [`CreateClassProxy`][5] implementations - they are almost identical!)
### MyProxyGenerator.cs
csharp
class MyProxyGenerator : ProxyGenerator
{
	object _target;
	public MyProxyGenerator(object target) {
		_target = target; // this is the missing piece, we'll have to pass it on to Castle proxy
	}
	// this method is 90% taken from the library source. I only had to tweak two lines (see below)
	public override object CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options, object[] constructorArguments, params IInterceptor[] interceptors)
	{
		if (classToProxy == null)
		{
			throw new ArgumentNullException("classToProxy");
		}
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		if (!classToProxy.GetTypeInfo().IsClass)
		{
			throw new ArgumentException("'classToProxy' must be a class", "classToProxy");
		}
		CheckNotGenericTypeDefinition(classToProxy, "classToProxy");
		CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");
		Type proxyType = CreateClassProxyTypeWithTarget(classToProxy, additionalInterfacesToProxy, options); // these really are the two lines that matter
		List<object> list =  BuildArgumentListForClassProxyWithTarget(_target, options, interceptors); 		 // these really are the two lines that matter
		if (constructorArguments != null && constructorArguments.Length != 0)
		{
			list.AddRange(constructorArguments);
		}
		return CreateClassProxyInstance(proxyType, list, classToProxy, constructorArguments);
	}
}
if all of the above was relativaly straightforward, actually feeding it into `Moq` is going to be somewhat of a hack. As I mentioned, most of the structures are marked `internal` so we'll have to use reflection to get through:
### MyMock.cs
csharp
public class MyMock<T> : Mock<T>, IDisposable where T : class
{
	void PopulateFactoryReferences()
	{
		// Moq tries ridiculously hard to protect their internal structures - pretty much every class that could be of interest to us is marked internal
		// All below code is basically serving one simple purpose = to swap a `ProxyGenerator` field on the `ProxyFactory.Instance` singleton
		// all types are internal so reflection it is
		// I will invite you to make this a bit cleaner by obtaining the `_generatorFieldInfo` value once and caching it for later
		var moqAssembly = Assembly.Load(nameof(Moq));
		var proxyFactoryType = moqAssembly.GetType("Moq.ProxyFactory");
		var castleProxyFactoryType = moqAssembly.GetType("Moq.CastleProxyFactory");		
		var proxyFactoryInstanceProperty = proxyFactoryType.GetProperty("Instance");
		_generatorFieldInfo = castleProxyFactoryType.GetField("generator", BindingFlags.NonPublic | BindingFlags.Instance);		
		_castleProxyFactoryInstance = proxyFactoryInstanceProperty.GetValue(null);
		_originalProxyFactory = _generatorFieldInfo.GetValue(_castleProxyFactoryInstance);//save default value to restore it later
	}
	public MyMock(T targetInstance) {		
		PopulateFactoryReferences();
		// this is where we do the trick!
		_generatorFieldInfo.SetValue(_castleProxyFactoryInstance, new MyProxyGenerator(targetInstance));
	}
	
	private FieldInfo _generatorFieldInfo;
	private object _castleProxyFactoryInstance;
	private object _originalProxyFactory;
	public void Dispose()
	{
		 // you will notice I opted to implement IDisposable here. 
		 // My goal is to ensure I restore the original value on Moq's internal static class property in case you will want to mix up this class with stock standard implementation
		 // there are probably other ways to ensure reference is restored reliably, but I'll leave that as another challenge for you to tackle
		_generatorFieldInfo.SetValue(_castleProxyFactoryInstance, _originalProxyFactory);
	}
}
given we've got the above working, the actual solution would look like so:
csharp
	var config = new A()
	{
		Test = "TEST"
	};
	using (var superMock = new MyMock<A>(config)) // now we can pass instances!
	{
		superMock.CallBase = true; // you still need this, because as far as Moq is oncerned it passes control over to CastleDynamicProxy	
		var o1 = superMock.Object;
		Console.WriteLine(o1.ReturnTest()); // but this should return TEST
	}
hopefully this helps.
  [1]: http://www.nudoq.org/#!/Packages/Moq/Moq/Mock/P/CallBase
  [2]: http://www.castleproject.org/projects/dynamicproxy/
  [3]: https://github.com/castleproject/Core/blob/master/docs/dynamicproxy-kinds-of-proxy-objects.md#composition-based
  [4]: https://github.com/castleproject/Core/blob/master/src/Castle.Core/DynamicProxy/ProxyGenerator.cs#L1156
  [5]: https://github.com/castleproject/Core/blob/master/src/Castle.Core/DynamicProxy/ProxyGenerator.cs#L1420
