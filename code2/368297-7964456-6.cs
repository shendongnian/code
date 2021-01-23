    public class DataPoints
    {
    	private readonly PointF[] rawData; //raw measurement pairs
    	public float xMax; //max value on X axis
    	public float yMax; //max value on Y axis
    
    	public DataPoints(PointF[] rawData)
    	{
    		if (rawData == null)
    			throw new ArgumentNullException("rawData");
    			
    		this.rawData = rawData;
    	}
    
    	public float GetMaxX()
    	{
    		//DO other stuff to find max X
    		return MAX_X; //as float
    	}
    }
