    var point = new PointF(1.2f, 2.5f);
    var rectangles = new RectangleF[]
    {
    	new RectangleF(1, 1, 1, 1),
    	new RectangleF(3, 1, 1, 1),
    	new RectangleF(5, 2, 1, 1),
    };
    
    var hit = rectangles
    	.Select(x =>
    	{
			if (IsBetween(point.X, x.Left, x.Left + x.Width))
				return new { Rectangle = x, Distance = GetClosestDistance(point.Y, x.Top - x.Height, x.Top) as float? };
			else if (IsBetween(point.X, x.Top - x.Height, x.Top))
				return new { Rectangle = x, Distance = GetClosestDistance(point.Y, x.Left, x.Left + x.Width) as float? };
			else return new { Rectangle = x, Distance = default(float?) };
    	})
    	.Where(x => x.Distance != null)
    	.OrderBy(x => x.Distance)
    	.FirstOrDefault()?.Rectangle;
    
    bool IsBetween(float value, float lBound, float uBound) => lBound <= value && value <= uBound;
    float GetClosestDistance(float value, float p0, float p1) => Math.Min(Math.Abs(p0 - value), Math.Abs(p1 - value));
