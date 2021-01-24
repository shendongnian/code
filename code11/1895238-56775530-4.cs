    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object obj) => obj is Point other && x == other.x && y == other.y;
        public override int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
    }
    class Triangle {
    	public double x1 {get; set;}
    	public double x2 {get; set;}
    	public double x3 {get; set;}
    	public double y1 {get; set;}
    	public double y2 {get; set;}
    	public double y3 {get; set;}	
    	
    	protected virtual IEnumerable<Point> Points => new []{
    		 new Point(x1, y1),
    		 new Point(x2, y2),
    		 new Point(x3, y3),
    	};
    	
    	public Point HasTwoMatchingPoints(Triangle other){
    		var notMatchingPoints = Points.Except(other.Points);
    
    		return notMatchingPoints.Count() == 1
    			? notMatchingPoints.First() // it means another 2 points are identical
    			: null;
    	}
    }
    class Rectangle : Triangle
    {
        public Rectangle(Triangle triangle, Point point)
        {
            x1 = triangle.x1;
            x2 = triangle.x2;
            x3 = triangle.x3;
            x4 = point.x;
            y1 = triangle.y1;
            y2 = triangle.y2;
            y3 = triangle.y3;
            y4 = point.y;
        }
        public double x4 { get; set; }
        public double y4 { get; set; }
    }
