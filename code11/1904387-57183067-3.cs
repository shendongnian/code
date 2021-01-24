	class Program
	{
		static void Main(string[] args)
		{
			Rectangle.Sides = 4;
			Pentagon.Sides = 5;
			Console.WriteLine(Rectangle.Sides); // 4
			Console.WriteLine(Pentagon.Sides); // 5
			Console.WriteLine(Circle.Sides); // Throws NotImplementedException
            Console.WriteLine(Triangle.Sides); // Throws NotImplementedException
		} 
	}
	public abstract class Shape
	{
		public static int Sides { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	}
	public class Rectangle : Shape
	{
		public new static int Sides { get; set; }
	}
	public class Pentagon : Shape
	{
		public new static int Sides { get; set; }
	}
    public class Circle : Shape
	{ // Circle does not have sides
	}
    public class Triangle : Shape
    {
        // We forget to implement the Sides property
    }
