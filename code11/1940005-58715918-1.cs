    public class Root
    {
    	public string Section { get; set; }
    	
    	[JsonConverter(typeof(NaicsConverter))]
    	public Naics Naics { get; set; }
    }
    
    // This isn't ideal, but it's quick and dirty and should get you started
    public class Naics : List<Naic>
    {
    	
    }
    
    public class Naic
    {
    	public string NaicsName { get; set; }
    	public bool IsPrimary { get; set; }
    	public string IsSmallBusiness { get; set; }
    	public long NaicsCode { get; set; }
    }
