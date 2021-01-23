    public sealed partial class EntityClass
    {
    	[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors",
    		Justification = "EF 4.1 requires them to be virtual, and RIA Services requires the collections to be instantiated.")]
    	public EntityClass()
    	{
    		OtherEntities = new List<OtherEntity>();
    	}
    	
    	public virtual ICollection<OtherEntity> OtherEntities { get; set; }
    }
