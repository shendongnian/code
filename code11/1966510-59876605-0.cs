csharp
public class Factory
{
    public ICommon Init<T>(T infoData)
    {
        if (infoData is DBInfoData dbInfoData) {
			return new ClassA(dbInfoData);
		}
		if (infoData is WebInfoData webInfoData) {
			return new ClassB(webInfoData);
		}
		
		throw new Exception($"Cannot create instance for info data of type {infoData.GetType().Name}");
    }
}
And to test it:
csharp
	var factory = new Factory();
	
	var t1 = factory.Init(new DBInfoData()); // will be ClassA
	var t2 = factory.Init(new WebInfoData()); // ClassB
To sophisticate it, you could introduce [type constraint][2] on your generic `T` class to make sure you can only pass appropriate types. For the current situation, you could create a [marker interface][3] for your classes `DBInfoData` and `WebInfoData` by introducing an empty interface say `IInfoData`. Then you have to inherit your classes like this:
csharp
public interface IInfoData {}
public class DBInfoData : IInfoData
{
    public string Server { get; set; }
    public string Database { get; set; }
}
public class WebInfoData : IInfoData
{
    public string URL { get; set; }
    public int Port { get; set; }
}
Now both inherits from (actually 'marked by') your base interface. Introduce a constraint to your factory to allow only descendants of `IInfoData` to be passed as an argument (so either `DBInfoData` or `WebInfoData`) by adding a constraint shown in the docs I linked above:
csharp
public class Factory
{
    public ICommon Init<T>(T infoData) where T: IInfoData
    {
        if (infoData is DBInfoData dbInfoData) {
			return new ClassA(dbInfoData);
		}
		if (infoData is WebInfoData webInfoData) {
			return new ClassB(webInfoData);
		}
		
		throw new Exception($"Cannot create instance for info data of type {infoData.GetType().Name}");
    }
}
Any type other than the descendants of `IInfoData` will cause a compilation error, and you're done. Use it like in my previous example:
csharp
	var factory = new Factory();
	
	var t1 = factory.Init(new DBInfoData()); // will be ClassA
	var t2 = factory.Init(new WebInfoData()); // ClassB
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/is
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
  [3]: https://en.wikipedia.org/wiki/Marker_interface_pattern
