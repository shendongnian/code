List<List<PointF>> splitted_list = new List<List<PointF>>();
float x = 0;
float y = 0;
float offsetX = 0;
float offsetY = 0;
foreach(PointF p in points)
{
	if (splitted_list.Count() > 0)
	{
		if (splitted_list.Last().Count() >= 2 && (p.X - x != offsetX || p.Y - y != offsetY))
		{
			List<PointF> list_points = new List<PointF>();
			list_points.Add(p);
			splitted_list.Add(list_points);
		}
		else
		{
			splitted_list.Last().Add(p);
			offsetX = p.X - x;
			offsetY = p.Y - y;
		}
	}
	else
	{
		List<PointF> list_points = new List<PointF>();
		list_points.Add(p);
		splitted_list.Add(list_points);
	}
	x = p.X;
	y = p.Y;
}
Everytime one of the offsets changes, I create a new list and I add it to my "list of lists" (it works regardless of the offset's value).
So the result is a list of series of points. If you HAVE to use those series as arrays of points, you can simply convert the lists to arrays by using the method ToArray().
