csharp
void Main()
{
	var myObj = GetObject(guid, A, C, H, M, T);
}
public T GetObject<T>(Guid identifier, params IObjectCollection<T>[] collections)
	where T : ObjectBase
{
	foreach (var collection in collections)
	{
		var item = collection.FirstOrDefault(o => o.GuidId == identifier);
		if (item != null) return item;
	}
	return default;
}
public class ObjectBase
{
	public Guid GuidId { get; }
}
