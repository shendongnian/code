    public interface Shape
	{
		int Sides { get; }
	}
	public class Rectangle : Shape
	{
		public int Sides { get { return 4; } }
	}
	public class Pentagon : Shape
	{
		public int Sides { get { return 5; } }
	}
	public class ShapeFactory
	{
		public static Shape CreateFromFile(string path)
		{
			// your logic to create the shapes
		}
	}
