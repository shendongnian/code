    [MetadataTypeAttribute(typeof(SomeClassCustomMetaData))]
    public partial class SomeClass
    {
    
    }
    
    public class SomeClassCustomMetaData
    {
    	[Required]
    	public string Name { get; set; }
    	[InverseProperty("Father")]
    	public virtual Parent ParentClass { get; set; }
    	[InverseProperty("Mother")]
    	public virtual Parent ParentClass1 { get; set; }
    }
