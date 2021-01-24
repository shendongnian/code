csharp
public readonly struct NamedProperty<TValue>
{
	public NamedProperty(string name, TValue value)
	{
		Name = name;
		Value = value;
	}
	public string Name { get; }
	public TValue Value { get; }
	public static implicit operator TValue (NamedProperty<TValue> obj)
		=> obj.Value;
	public static implicit operator NamedProperty<TValue>(TValue value)
		=> new NamedProperty<TValue>(null, value);
}
public interface ISelfTracker<T> 
	where T : class, ISelfTracker<T>
{
	Tracker<T> Tracker { get; set; }
}
public class NamedData : ISelfTracker<NamedData>
{
	public virtual NamedProperty<int> A { get; set; }
	public virtual NamedProperty<int> B { get; set; }
	public Tracker<NamedData> Tracker { get; set; }
}
Basically I've copy-pasted the original `Data` model but changed all its properties to be aware of their names.
Then the tracker itself:
csharp
public class Tracker<T> 
	where T : class, ISelfTracker<T>
{
	public T Instance { get; }
	public T Proxy { get; }
	public Tracker(T instance)
	{
		Instance = instance;
		Proxy = new ProxyGenerator().CreateClassProxyWithTarget<T>(Instance, new TrackingNamedProxyInterceptor<T>(this));
		Proxy.Tracker = this;
	}
	public void RecordChange(string setterName, string getterName)
	{
	}
	public void UnTrackChange(string setterName)
	{
	}
}
The interceptor for Castle.DynamicProxy:
csharp
public class TrackingNamedProxyInterceptor<T> : IInterceptor
	where T : class, ISelfTracker<T>
{
	private const string SetterPrefix = "set_";
	private const string GetterPrefix = "get_";
	private readonly Tracker<T> _tracker;
	public TrackingNamedProxyInterceptor(Tracker<T> proxy)
	{
		_tracker = proxy;
	}
	public void Intercept(IInvocation invocation)
	{
		if (IsSetMethod(invocation.Method))
		{
			string propertyName = GetPropertyName(invocation.Method);
			dynamic value = invocation.Arguments[0];
			var propertyType = value.GetType();
			if (IsOfGenericType(propertyType, typeof(NamedProperty<>)))
			{
				if (value.Name == null)
				{
					_tracker.UnTrackChange(propertyName);
				}
				else
				{
					_tracker.RecordChange(propertyName, value.Name);
				}
				var args = new[] { propertyName, value.Value };
				invocation.Arguments[0] = Activator.CreateInstance(propertyType, args);
			}
		}
		invocation.Proceed();
	}
	private string GetPropertyName(MethodInfo method)
		=> method.Name.Replace(SetterPrefix, string.Empty).Replace(GetterPrefix, string.Empty);
	private bool IsSetMethod(MethodInfo method)
		=> method.IsSpecialName && method.Name.StartsWith(SetterPrefix);
	private bool IsOfGenericType(Type type, Type openGenericType)
		=> type.IsGenericType && type.GetGenericTypeDefinition() == openGenericType;
}
And the modified entry point:
csharp
static void Main(string[] args)
{
	var data = new Data() { A = 1, B = 2 };
	NamedData namedData = Map(data);
	var proxy = new Tracker<NamedData>(namedData).Proxy;
	Runner.Run(proxy);
	Console.ReadLine();
}
The `Map()` function actually maps `Data` to `NamedData` filling in property names.
