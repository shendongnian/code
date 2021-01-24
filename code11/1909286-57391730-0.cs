    public class Sample
	{
		// add data to that variables.
		System.Collections.Generic.Dictionary<double, Point> pointPerElement = new System.Collections.Generic.Dictionary<double, Point>();
		System.Collections.Generic.Dictionary<double, Cube> cubePerElement = new System.Collections.Generic.Dictionary<double, Cube>();
		System.Collections.Generic.List<double> elements = new System.Collections.Generic.List<double>();
		private void Calculate()
		{
			foreach (var element in elements)
			{
				if (pointPerElement.ContainsKey(element) == false || cubePerElement.ContainsKey(element) == false)
				{
					continue;
				}
				var point = pointPerElement[element];
				var cube = cubePerElement[element];
				if (cube.IsBouded(point))
				{
					// add point or cube or element to list.
				}
			}
		}
	}
		
	private struct Point
	{
		public double x;
		public double y;
		public double z;
		public Point(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public static Point GetVector(Point from, Point to)
		{
			return new Point(to.x - from.x, to.y - from.y, to.z - from.z);
		}
	}
	private struct Range
	{
		public double min;
		public double max;
		public double length;
		public double center;
		public Range(double min, double max)
		{
			System.Diagnostics.Debug.Assert(min < max);
			this.min = min;
			this.max = max;
			this.length = max - min;
			this.center = length * 0.5;
		}
	}
	private struct Cube
	{
		public Range xRange;
		public Range yRange;
		public Range zRange;
		private Point center;
		public Cube(Range xRange, Range yRange, Range zRange)
		{
			this.xRange = xRange;
			this.yRange = yRange;
			this.zRange = zRange;
			this.center = new Point(xRange.center, yRange.center, zRange.center);
		}
		public bool IsBouded(Point point)
		{
			var v = Point.GetVector(point, this.center);
			var doubledV = new Point(v.x * 2, v.y * 2, v.z * 2);
			return doubledV.x <= this.xRange.length
				&& doubledV.y <= this.yRange.length
				&& doubledV.z <= this.yRange.length;
		}
	}
