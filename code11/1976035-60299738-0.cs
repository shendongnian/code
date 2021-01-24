public abstract class Drawer
{
	public abstract void Draw();
}
public class CircleDrawer : Drawer
{
	private readonly Circle _circle;
	public CircleDrawer(Circle circle)
	{
		_circle = circle;
	}
	public override void Draw() { }
}
public class RectangleDrawer : Drawer
{
	private readonly Rectangle _rectangle;
	public RectangleDrawer(Rectangle rectangle)
	{
		_rectangle = rectangle;
	}
	public override void Draw() { }
}
public class Picture
{
	public double Scale { get; set; }
	[XmlArrayAttribute("Shapes")]
	public Collection<Shape> Shapes { get; set; }
	public void Setup()
	{
		List<Drawer> drawers = new List<Drawer>();
		foreach (Shape shape in Shapes)
		{
			if (shape is Circle)
			{
				drawers.Add(new CircleDrawer(shape as Circle));
			}
			else if (shape is Rectangle)
			{
				drawers.Add(new RectangleDrawer(shape as Rectangle));
			}
			else
			{
			}
		}
		foreach (Drawer drawer in drawers)
		{
			drawer.Draw();
		}
	}
	public static Picture FromXml(XmlReader xmlReader)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Picture));
		return serializer.Deserialize(xmlReader) as Picture;
	}
}
