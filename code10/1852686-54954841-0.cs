    public static void DrawRectangles(this Image thisImage, List<RectangleF> rectangles, Color color)
    {
    	using (var g = Graphics.FromImage(thisImage))
    	{
    		var brush = new SolidBrush(color);
    		g.FillRectangles(brush, rectangles.ToArray());
    	}
    }
    
    public static void DrawRectangles(this Image thisImage, List<Rectangle> rectangles, Color color)
    {
    	var rectangleFs = rectangles.Select(x => (RectangleF) x).ToList();
    	DrawRectangles(thisImage, rectangleFs, color);
    }
