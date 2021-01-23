    public static bool PolyContainsPoint(List<Point> points, Point p) {
	bool inside = false;
	// An imaginary closing segment is implied,
	// so begin testing with that.
	Point v1 = points[points.Count - 1];
	foreach (Point v0 in points)
	{
		double d1 = (p.Y - v0.Y) * (v1.X - v0.X);
		double d2 = (p.X - v0.X) * (v1.Y - v0.Y);
		if (p.Y < v1.Y)
		{
			// V1 below ray
			if (v0.Y <= p.Y)
			{
				// V0 on or above ray
				// Perform intersection test
				if (d1 > d2)
				{
					inside = !inside; // Toggle state
				}
			}
		}
		else if (p.Y < v0.Y)
		{
			// V1 is on or above ray, V0 is below ray
			// Perform intersection test
			if (d1 < d2)
			{
				inside = !inside; // Toggle state
			}
		}
		v1 = v0; //Store previous endpoint as next startpoint
	}
	return inside; 
