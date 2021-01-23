    [DataContract(Name = "baseclass", Namespace = "")]
    [KnownType(typeof(DerivedClass))]
    public class BaseClass
    {
    	[DataMember(Name = "attributes", EmitDefaultValue = false)]
    	 public virtual SomeType Fields { get; set; }
    }
    
    [DataContract(Name = "derivedclass", Namespace = "")]
    public class DerivedClass : BaseClass
    {
    	public override SomeType Fields
    	{
    		get { return null; }
    	}
    
    	[DataMember(Name = "fields")]
    	public SomeType DerivedFields
    	{
    		get { return base.Fields; }
    	}
    }
