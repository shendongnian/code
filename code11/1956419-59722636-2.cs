cs
public class Item
{
	public string Id { get; set; } = default!;
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
}
Another option is to use `AllowNull/DisallowNull` [precondition attributes](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-attributes#specify-preconditions-allownull-and-disallownull) for that. 
 - `AllowNull` A non-nullable input argument may be null.
 - `DisallowNull` A nullable input argument should never be null.
But these attributes only affect nullable analysis for the callers of members that are annotated with them. You should apply them to fields, properties, indexers and parameters.
So, you can decorate you class with `AllowNull` attribute
cs
public class Item
{
	[AllowNull]
	public string Id { get; set; }
	[AllowNull]
	public string Name { get; set; }
	[AllowNull]
	public string Description { get; set; }
}
and the following line doesn't show warning
cs
var item = new Item();
item.Name = null;
but this shows
cs
var item = new Item { Name = null };
because nullable analysis incorrectly work with object initializers, there is open GitHub [issue](https://github.com/dotnet/roslyn/pull/40127) for that
