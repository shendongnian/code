csharp
public interface IReadOnlyConnectionProperties 
{
    string Name { get; } 
    bool Enabled { get; } 
} 
If you don't control the type, you can make such an interface and create a wrapper type that will implement it. It would take `ConnectionProperties` in its ctor and proxy get-accesses to it properties. The same way a [`ReadOnlyCollection`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlycollection-1?view=netframework-4.8) does.
csharp
internal ReadOnlyConnectionProperties : IReadOnlyConnectionProperties 
{
    private readonly ConnectionProperties _wrapped;
    
    public string Name => _wrapped.Name;
    public bool Enabled => _wrapped.Enabled;
    public ReadOnlyConnectionProperties(
        ConnectionProperties connectionProperties) =>
        _wrapped = connectionProperties;
} 
Note that this assumes a level of trust to the user. If using the first solution, there's nothing stopping the consumers from upcasting the interface back to `ConnectionProperties`. The second solution avoids this problem, and is the one I'd recommend. Just remember that in both cases changes to the underlying `ConnectionProperties` will be reflected in whatever proxies you give to your consumers. 
