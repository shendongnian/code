    public abstract class Shape
    {
        protected List<IPointFactory> points = new List<IPointFactory>();
    	
    	public IEnumerable<Point> GetPoints() => points.Select(p => p.CreatePoint()); 
    	
    }
    
    public class Square : Shape
    {
    	public Square()
    	{
    		points.Add(new CartesianFactory(0.0,0.0));
    		points.Add(new CartesianFactory(1.0,0.0));
    		points.Add(new CartesianFactory(0.0,1.0));
    		points.Add(new CartesianFactory(1.0,1.0));
    	}
    }
