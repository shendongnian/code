cs
public class Item
{
	public string Id { get; set; } = default!;
	public string Name { get; set; } = default!;
	public string Description { get; set; } = default!;
}
Since your DTO is populated from DynamoDB, you can use `MaybeNull/NotNull` [postcondition attributes](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-attributes#specify-post-conditions-maybenull-and-notnull) to control the nullability 
 - `MaybeNull` A non-nullable return value may be null. 
 - `NotNull` A nullable return value will never be null.
But these attributes only affect nullable analysis for the callers of members that are annotated with them. Typically, you apply these attributes to method returns, properties and indexers getters.
So, you can consider all of your properties non-nullable ones and decorate them with `MaybeNull` attribute, indicating them return possible `null` value
cs
public class Item
{
	public string Id { get; set; } = "";
	[MaybeNull] public string Name { get; set; } = default!;
	[MaybeNull] public string Description { get; set; } = default!;
}
The following example shows the usage of updated `Item` class. As you can see, second line doesn't show warning, but third does
cs
var item = new Item();
string id = item.Id;
string name = item.Name; //warning CS8600: Converting null literal or possible null value to non-nullable type.
Or you can make all properties a nullable ones and use `NoNull` to indicate the return value can't be `null` (`Id` for example)
cs
public class Item
{
	[NotNull] public string? Id { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; }
}
The warning will be the same with previous example.
There is also `AllowNull/DisallowNull` [precondition attributes](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-attributes#specify-preconditions-allownull-and-disallownull) for input parameters, properties and indexers setters, working on the similar way.
 - `AllowNull` A non-nullable input argument may be null.
 - `DisallowNull` A nullable input argument should never be null.
I don't think that it will help you, since your class is populated from database, but you can use them to control the nullability of properties setters, like this for the first option
cs
[MaybeNull, AllowNull] public string Description { get; set; }
And for second one
cs
[NotNull, DisallowNull] public string? Id { get; set; }
Some helpful details and examples of post/preconditions can be found in this [devblog article](https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types/)
