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
