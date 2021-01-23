    public class Customer : Entity
    {
    	[Required]
    	public string Name { get; set; }
    
    	[UpdateOnSave]
    	public DateTime Modified { get; set; }
    
    	public DateTime Created { get; set; }
    }
