    public class Destination
    {
    	public Destination()
    	{
    		HomeAddess = new Address();
    	}
    	
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    
    	public Address HomeAddress { get; set; }
    }
    
    AutoMapper.Create<Source, Destination>()
    	.ForMemeber(destination => destination.Address.PostalCode,
    				options => options.MapForm(
    					source => source.ZipCode
    				)
    	);
