    public class Rootobject
    {
    	public List<Sample> Samples { get; set; }
    }
    
    public class Sample
    {
    	public DateTime Date { get; set; }
    	public float Temperature { get; set; }
    	public int Ph { get; set; }
    	public int Phosphate { get; set; }
    	public int Chloride { get; set; }
    	public int Nitrate { get; set; }
    }
