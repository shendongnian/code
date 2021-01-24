    public abstract class Shape
    {
        public abstract int Sides { get; }
    }
    
    public class Circle : Shape
    {
        public override int Sides => 1;
    }
    
    public class Hexagon : Shape
    {
        public override int Sides => 6;
    }
    
    Shape[] shapes = new Shape[] { new Circle(), new Hexagon() };
    foreach (Shape shape in shapes)
    {
        Console.WriteLine($"Shape has {shape.Sides} sides");
    }
