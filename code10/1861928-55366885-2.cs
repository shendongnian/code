	var hit = RayTest(point, rectangles, RayDirections.Right | RayDirections.Down) // or, try just `Down`
		.Where(x => x.Success)
		.OrderBy(x => x.Distance)
		.FirstOrDefault()?.Target;
    [Flags]
    public enum RayDirections { None = 0, Left = 1 << 0, Up = 1 << 1, Right = 1 << 2, Down = 1 << 3, All = (1 << 4) - 1 }
    public class RayHit<T>
    {
    	public T Target { get; }
    	public float? Distance { get; }
    	public bool Success => Distance.HasValue;
    	
    	public RayHit(T target, float? distance)
    	{
    		this.Target = target;
    		this.Distance = distance;
    	}
    }
    
    public IEnumerable<RayHit<RectangleF>> RayTest(PointF point, IEnumerable<RectangleF> rectangles, RayDirections directions = RayDirections.All)
    {
    	if (directions == RayDirections.None)
    		return Enumerable.Empty<RayHit<RectangleF>>();
    	
    	var ray = new
    	{
    		Horizontal = new
    		{
    			LBound = directions.HasFlag(RayDirections.Left) ? float.MinValue : point.X,
    			UBound = directions.HasFlag(RayDirections.Right) ? float.MaxValue : point.X,
    		},
    		Vertical = new
    		{
    			LBound = directions.HasFlag(RayDirections.Down) ? float.MinValue : point.Y,
    			UBound = directions.HasFlag(RayDirections.Up) ? float.MaxValue : point.Y,
    		},
    	};
    	
    	return rectangles
    		.Select(x =>
    		{
    			float left = x.Left, right = x.Left + x.Width;
    			float top = x.Top, bottom = x.Top - x.Height;
    			
    			if (IsBetween(point.X, left, right) && (IsBetween(top, ray.Vertical.LBound, ray.Vertical.UBound) || IsBetween(bottom, ray.Vertical.LBound, ray.Vertical.UBound)))
    				return new RayHit<RectangleF>(x, GetClosestDistance(point.Y, bottom, top) as float?);
    			else if (IsBetween(point.X, bottom, top) && (IsBetween(left, ray.Horizontal.LBound, ray.Horizontal.UBound) || IsBetween(right, ray.Horizontal.LBound, ray.Horizontal.UBound)))
    				return new RayHit<RectangleF>(x, GetClosestDistance(point.Y, left, right) as float?);
    			else return new RayHit<RectangleF>(x, default);
    		});
    	
    	bool IsBetween(float value, float lBound, float uBound) => lBound <= value && value <= uBound;
    	float GetClosestDistance(float value, float p0, float p1) => Math.Min(Math.Abs(p0 - value), Math.Abs(p1 - value));
    }
