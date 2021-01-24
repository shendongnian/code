lang-csharp
void Main()
{
	Console.WriteLine(Protocols.ValidProtocol("2019/0002391")); //True
	Console.WriteLine(Protocols.ValidProtocol("2018/0000000")); //False
}
// Define other methods and classes here
public static class Protocols
{
	public static bool ValidProtocol(string protocol)
	{
		return _validProtocols.Contains(protocol);
	}
	
	private static readonly HashSet<string> _validProtocols = new HashSet<string>
	{
		"2019/0002391",
		"2019/0002390",
		"2019/0001990"
		//etc, etc...
	};
}
A solution like this would probably not be ideal if the list of `string`s you need to check against changes often. You'd probably want to pull the list from an external source like a file or a database if you need to modify it often.
