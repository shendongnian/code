	public Dictionary<MyAttributeKeysEnum, PropertyBagValue> MyAttributes { get; set; }
	public class PropertyBagValue
	{
		public object AsObject { get; set; }
		public string AsString { get; set; }
		public int AsInt { get; set; }
		// ...
	}
