	private static void DrawRectangles<T>(this Image thisImage, List<T> rectangles, Color color, Action<Graphics, Brush, T[]> fill)
	{
		using (var g = Graphics.FromImage(thisImage))
		{
			var brush = new SolidBrush(color);
			fill(g, brush, rectangles.ToArray());
		}
	}
	public static void DrawRectangles(this Image thisImage, List<RectangleF> rectangles, Color color)
	{
		thisImage.DrawRectangles(rectangles, color, (g, b, rs) => g.FillRectangles(b, rs));
	}
	public static void DrawRectangles(this Image thisImage, List<Rectangle> rectangles, Color color)
	{
		thisImage.DrawRectangles(rectangles, color, (g, b, rs) => g.FillRectangles(b, rs));
	}
