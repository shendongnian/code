    public enum Line
    {
    	ABC,
    	PMV,
    	DGE,
    	RAR
    }
    
    public enum Facility
    {
       IWA,
       CHI,
       DET,
       MEX
    }
    
    public class Serial
    {
    	public Line Line { get; set; }
    	public Facility Facility { get; set; }
       	public int SequenceNumber { get; set; }
    	
    	public override string ToString()
    	{
    		var sequenceString = SequenceNumber.ToString().PadLeft(10, '0');
    		return $"{Line.ToString()}{Facility.ToString()}{sequenceString }";
    	}
    }
