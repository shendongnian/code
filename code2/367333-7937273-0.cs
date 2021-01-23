	public class OuterClass
	{
		[DataMember(Name = "Assets", Order = 10),
		XmlElement(ElementName = "Asset")]
		public List<string> Assets { get; set; }
		...
		//[DataContract(Name = "Asset", Namespace = "")]
		//public class AssetClass
		//{
		//	[DataMember(Name = "Asset", Order = 10)]
		//	public string Asset { get; set; }
		//	...
		//} 
	}
