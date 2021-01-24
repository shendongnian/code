csharp
void Main()
{
	var harmony = new Harmony("test");
	harmony.PatchAll();
	
	var group = new StatusItemGroup();
	var items = new List<StatusItemGroup.Entry>() { StatusItemGroup.Entry.Make("A"), StatusItemGroup.Entry.Make("B") };
	Traverse.Create(group).Field("items").SetValue(items);
	
	var enumerator = group.GetEnumerator();
	while(enumerator.MoveNext())
		Console.WriteLine(enumerator.Current.id);
}
[HarmonyPatch]
class Patch
{
	public class ProxyEnumerator<T> : IEnumerable<T>
	{
		public IEnumerator<T> enumerator;
		public Func<T, T> transformer;
		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
		public IEnumerator<T> GetEnumerator()
		{
			while(enumerator.MoveNext())
				yield return transformer(enumerator.Current);
		}
	} 
	[HarmonyPatch(typeof(StatusItemGroup), "GetEnumerator")]
	static IEnumerator<StatusItemGroup.Entry> Postfix(IEnumerator<StatusItemGroup.Entry> enumerator)
	{
		StatusItemGroup.Entry Transform(StatusItemGroup.Entry entry)
		{
			entry.id += "+";
			return entry;
		}
		var myEnumerator = new ProxyEnumerator<StatusItemGroup.Entry>()
		{
			enumerator = enumerator,
			transformer = Transform
		};
		return myEnumerator.GetEnumerator();
	}
}
public class StatusItemGroup
{
	public IEnumerator<Entry> GetEnumerator()
	{
		return items.GetEnumerator();
	}
	private List<Entry> items = new List<Entry>();
	public struct Entry
	{
		public string id;
		public static Entry Make(string id) { return new Entry() { id = id }; }
	}
}
