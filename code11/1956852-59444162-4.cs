cs
public class WareHouseLocation : ICloneable
{
	public int FloorID { get; set; }
	public List<I3DStorageObject> storage = new List<I3DStorageObject>();
	public double MaxVolume;
	public double MaxWeight;
	...
	public object Clone()
	{
		var copy = (WareHouseLocation)MemberwiseClone();
		copy.storage = storage.Select(item => (I3DStorageObject)item.Clone()).ToList();
		return copy;
	}
}
Since you have a `List` reference inside `WareHouseLocation` you have to properly clone this as well by implementing `ICloneable` for `I3DStorageObject` as well, because `MemberwiseClone` copy the reference only, not the referred object itself
cs
public class I3DStorageObject : ICloneable
{
	public double Volume { get; set; }
	public object Clone()
	{
		return MemberwiseClone();
	}
}
You can also look at [MSDN][1] for details and examples of `MemberwiseClone` method and deep/shallow copy of objects
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone?view=netframework-4.8
