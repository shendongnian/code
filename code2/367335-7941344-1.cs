    public class OuterClass
    {
    	[DataMember(Name = "Assets", Order = 10)]
    	public ListAssetClass Assets { get; set; }
    	...
    	
    	//[DataContract(Name = "Asset123", Namespace = "")]
    	public class ListAssetClass
    	{
    		[XmlElement(ElementName = "Asset")]
    		public List<string> Assets { get; set; }
    		...
    	}
    }
