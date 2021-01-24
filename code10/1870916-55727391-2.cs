    public enum Shapes
    {
        Circle,
        Rectangle,
        Triangle
    }
    
    public interface IShape
    {
        void Draw(Color c);
    }
    
    public static class Shape
    {
        public static void ExampleClientCode()
        {
            var s = Shapes.Circle;
            // your enum looks like a "proper" object
            s.Draw(Color.AliceBlue);
        }
        public static IShape MkShape(this Shapes s)
        {
            switch (s)
            {
                case Shapes.Circle:
                    return new Circle();
                case Shapes.Rectangle:
                    return new Rectangle();
                case Shapes.Triangle:
                    return new Triangle();
                default:
                    throw new Exception("nasty enum means I can't have typesafe switch statement");
            }
        }
    
        public static void Draw(this Shapes s,Color c)
        {
            s.MkShape().Draw(c);
        }
    }
    
    public class Triangle : IShape
    {
        public void Draw(Color c)
        {
            //for demo purpose
            Console.WriteLine("Drawing Triangle with color " + c.Name);
    
        }
    }
    
    public class Circle : IShape
    {
        public void Draw(Color c)
        {
            //for demo purpose
            Console.WriteLine("Drawing Circle with color " + c.Name);
        }
    }
    
    public class Rectangle : IShape
    {
        public void Draw(Color c)
        {
            //for demo purpose
            Console.WriteLine("Drawing Rectangle with color " + c.Name);
        }
    }
