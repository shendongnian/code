    public class Class1{
	public Class1 ()
	{
		this.Loaded += (sender, args) =>
		{
			TextBlock text = new TextBlock();
			if (Orientation == Orientation.Vertical) 
			{
			  text.RenderTransform = new RotateTransform() { Angle = 270 };
			}
			double halfWidth = text.ActualWidth / 2;
			double x1 = (Orientation == Orientation.Horizontal) ? x - halfWidth : x;
			double y1 = (Orientation == Orientation.Horizontal) ? y : y + halfWidth;
			Canvas.SetLeft(text, x1);
			Canvas.SetTop(text, y1);
			Children.Add(text);
		};
	}
