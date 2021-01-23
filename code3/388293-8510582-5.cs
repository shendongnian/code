    public interface IMyInterface
    {
    	string Name { get; set; }
    	string Signature { get; set; }
    	int Checksum { get; set; }
    }
    
    public class ClassX : IMyInterface
    {
        	public string Name { get; set; }
        	public string Signature { get; set; }
        	public int Checksum { get; set; }
    	// Add the other properties here
    }
    
    public class ClassY : IMyInterface
    {
        	public string Name { get; set; }
        	public string Signature { get; set; }
        	public int Checksum { get; set; }
    	// Add the other properties here
    }
    
    public class ClassZ : IMyInterface
    {
        	public string Name { get; set; }
        	public string Signature { get; set; }
        	public int Checksum { get; set; }
    	// Add the other properties here
    }
