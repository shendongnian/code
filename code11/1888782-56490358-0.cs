    public class Rootobject
    {
    	public List<Sample> samples { get; set; }
    }
    
    public class Sample
    {
    	public DateTime date { get; set; }
    	public float temperature { get; set; }
    	public int pH { get; set; }
    	public int phosphate { get; set; }
    	public int chloride { get; set; }
    	public int nitrate { get; set; }
    }
