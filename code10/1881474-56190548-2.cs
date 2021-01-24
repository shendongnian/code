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
    
    	public IEnumerable<(float x, float y)> GetPoints()
    	{
    		yield return (x1, y1);
    		yield return (x2, y2);
    		yield return (x3, y3);
    	}
    
    	public bool IsAdjacentTo(TriangleRegistryObject other)
    	{
    		return this.GetPoints().Intersect(other.GetPoints()).Count() >= 2;
    	}
    }
    public static class EnumerableExtensions
    {
    	public static IEnumerable<IEnumerable<T>>
    		GetKCombs<T>(this IEnumerable<T> list, int length)
    	{
    		if (length == 1) return list.Select(t => new T[] { t });
    		return GetKCombs(list, length - 1)
    			.SelectMany(t => list.Where(o => !o.Equals(t.Last())),
    				(t1, t2) => t1.Concat(new T[] { t2 }));
    	}
    }
