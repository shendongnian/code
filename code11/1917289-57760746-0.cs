    void Main()
    {
    	List<string> linesX = new List<string>{"1","2","4"};
    	List<string> linesY = new List<string>{"-1","-2","-4"};
    	
    	List<Point> points = new List<Point>();
    	//assuming both linesX and linesY has the same lenght
    	for (int i = 0; i < linesX.Count; i++)
    	{
    		Point p = new Point(int.Parse(linesX[i]), int.Parse(linesY[i]));
    		points.Add(p);
    	}
    	
    	foreach (var point in points)
    	{
    		Console.WriteLine($"Point coordinate X,Y={point.X},{point.Y}");
    	}
    }
