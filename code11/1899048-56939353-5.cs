    public class SuccessOne
    {
    	public DateTime StartDate { get; set; }
    	public DateTime EndDate { get; set; }
    	public SuccessOneChild Object { get; set; }
    }
    
    public class SuccessOneChild
    {
    	public int Property1 { get; set; }
    	public string Property2 { get; set; }
    }
