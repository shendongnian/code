// Located in Library.DLL
public interface SomeInterface
{
	string SomeValue { get; }
}
// Located in Main.DLL
public class KnownType : SomeInterface
{
	public string SomeValue => $"{this.GetType().Name} ({this.GetType().GetHashCode()})";
}
// Get the types
var localType = typeof(KnownType);
var loadedType = Assembly.LoadFile(Assembly.GetExecutingAssembly().Location).GetType(localType.FullName);
Console.WriteLine($"{localType} {localType.GetHashCode()}");   // PRINTS: Main.KnownType 58225482
Console.WriteLine($"{loadedType} {loadedType.GetHashCode()}"); // PRINTS: Main.KnownType 54267293
Console.WriteLine($"Comparison: {loadedType == localType}");   // PRINTS: Comparison: False
// Create instances
var localInstance = Activator.CreateInstance(localType) as SomeInterface;
var loadedInstance = Activator.CreateInstance(loadedType) as SomeInterface;
Console.WriteLine(localInstance.SomeValue);  // PRINTS: KnownType (58225482)
Console.WriteLine(loadedInstance.SomeValue); // PRINTS: KnownType (54267293)
In short, ```Assembly.LoadFile```  will load the target assembly into a new AssemblyLoadContext isolating it from the default context. As no dependency resolver exist within this AssemblyLoadContext it will just reuse the known library assembly already loaded.
When executing this code, the hashcodes and comparison show that on runtime the type instances are different, even though its the exact same DLL. However, as they implement an interface that is within the shared assembly (`SomeInterface`), both objects can be cast to it and used.
See the guide on working with the AssemblyLoadContext [here](https://docs.microsoft.com/en-us/dotnet/core/dependency-loading/understanding-assemblyloadcontext). It also explains how you can share dependencies between different contexts if you have a custom `AssemblyLoadContext`. 
