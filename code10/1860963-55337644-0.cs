    public class RealEstateProperty
    {
    	public int Id { get; set; }
    	public string PostalCode { get; set; }
    	//... List of all properties
    
    	//[ForeignKey(nameof(PostalCode))] <-- remove this...
    	public virtual RealEstatePropertyPostalCodePriority PostalCodePriority { get; set; }
    }
    
    public class RealEstatePropertyPostalCodePriority
    {
    	public int Id { get; set; }
    
    	// This is a unique property on the database
    	public string PostalCode { get; set; }
    	public int? Sort { get; set; }
    
    	//[ForeignKey(nameof(PostalCode)), InverseProperty(nameof(RealEstateProperty.PostalCodePriority))] // <-- ... and this
    	public ICollection<RealEstateProperty> Properties { get; set; }
    }
