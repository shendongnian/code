cs
public class Item
{
	public string Id { get; set; } = default!;
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
}
Since your DTO is populated from DB, you can use `MaybeNull/NotNull` [postcondition attributes](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-attributes#specify-post-conditions-maybenull-and-notnull)  
 - `MaybeNull` A non-nullable return value may be null. 
 - `NotNull` A nullable return value will never be null.
But these attributes only affect nullable analysis for the callers of members that are annotated with. Typically, you apply them to method returns, properties and indexers getters.
So, you can consider all your properties non-nullable ones and decorate them with `MaybeNull` attribute, indicating them return possible `null` value
cs
public class Item
{
	public string Id { get; set; } = default!;
	[MaybeNull] public string Name { get; set; } = default!;
	[MaybeNull] public string Description { get; set; } = default!;
}
The second line doesn't show warning, but third does (assigning possible `null` value to non-nullable one)
cs
var item = new Item();
string id = item.Id;
string name = item.Name;
Or you can make all properties a nullable ones and use `NoNull` to indicate the return value can't be `null` (`Id` for example)
cs
public class Item
{
	[NotNull] public string? Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
}
There is also `AllowNull/DisallowNull` [precondition attributes](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-attributes#specify-preconditions-allownull-and-disallownull) for input arguments, properties and indexers setters, working on the similar way.
 - `AllowNull` A non-nullable input argument may be null.
 - `DisallowNull` A nullable input argument should never be null.
I can extend an example with them, if needed
