cs
    public class WareHouseLocation : ICloneable
	{
		public int FloorID { get; set; }
		public List<I3DStorageObject> storage = new List<I3DStorageObject>();
		public double MaxVolume;
		public double MaxWeight;
		public WareHouseLocation(double height, double width, double depth)
		{
			MaxVolume = height * width * depth;
			MaxWeight = 1000;
		}
		public bool hasAvailableVolumeForObject(I3DStorageObject s)
		{
			double currentVolume = 0;
			foreach (I3DStorageObject obj in storage)
			{
				currentVolume += obj.Volume;
			}
			double available = MaxVolume - currentVolume;
			return s.Volume <= available;
		}
		public object Clone()
		{
			var copy = (WareHouseLocation)MemberwiseClone();
			copy.storage = storage.Select(item => (I3DStorageObject)item.Clone()).ToList();
			return copy;
		}
	}
Since you have a `List` reference inside `WareHouseLocation` you have to properly clone this as well by implementing `ICloneable` for `I3DStorageObject` as well
cs
	public class I3DStorageObject : ICloneable
	{
		public double Volume { get; set; }
		public object Clone()
		{
			return MemberwiseClone();
		}
	}
