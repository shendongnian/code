    public class Program
    {
    	public static void Main()
    	{
    		var triangles = new List<TriangleRegistryObject>{
    			new TriangleRegistryObject{x1=10,y1=10, x2=12,y2=10, x3=1,y3=11},
    			new TriangleRegistryObject{x1=9,y1=11, x2=11,y2=11, x3=10,y3=10},
    			new TriangleRegistryObject{x1=9,y1=11, x2=11,y2=11, x3=10,y3=12},
    			new TriangleRegistryObject{x1=34,y1=14, x2=15,y2=11, x3=10,y3=12},
    		};
    
    		var sharedEdges = triangles.GetKCombs(2).Where(t => t.First().IsAdjacentTo(t.Skip(1).Take(1).Single())).Count();
    		Console.WriteLine($"Number shared edges: {sharedEdges}");
    	}
    }
    public class TriangleRegistryObject
    {
    	public float x1 { get; set; }
    	public float y1 { get; set; }
    	public float x2 { get; set; }
    	public float y2 { get; set; }
    	public float x3 { get; set; }
    	public float y3 { get; set; }
    	public bool Selected { get; set; }
    	public bool Visible { get; set; }
    
    	public bool IsAdjacentTo(TriangleRegistryObject other)
    	{
    		if (this.x1 == other.x1 && this.y1 == other.y1)
    		{
    			if (this.x2 == other.x2 && this.y2 == other.y2)
    			{
    				return true;
    			}
    			else if (this.x3 == other.x3 && this.y3 == other.y3)
    			{
    				return true;
    			}
    		}
    		else if (this.x2 == other.x2 && this.y2 == other.y2)
    		{
    			if (this.x1 == other.x1 && this.y1 == other.y1)
    			{
    				return true;
    			}
    			else if (this.x3 == other.x3 && this.y3 == other.y3)
    			{
    				return true;
    			}
    		}
    		else if (this.x3 == other.x3 && this.y3 == other.y3)
    		{
    			if (this.x1 == other.x1 && this.y1 == other.y1)
    			{
    				return true;
    			}
    			else if (this.x2 == other.x2 && this.y2 == other.y2)
    			{
    				return true;
    			}
    		}
    		return false;
    	}
    }
