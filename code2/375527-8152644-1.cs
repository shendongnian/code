    public abstract class Shape
    {
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Point Position { get; set; }
        public Shape(Color color, float rotation, Point position)
        {
            Color = color;
            Rotation = rotation;
            Position = position;
        }
        public void ChangeRotation(float amount)
        {
            Rotation += amount;
        }
        public abstract void Draw(Graphics graphics);
        public abstract bool WithinBounds(Point point);
    }
    public class Circle : Shape
    {
        public float Radius { get; set; }
        public Circle(Color color, float rotation, Point position)
            :base(color, rotation, position)
        {
        }
        public override void Draw(Graphics graphics)
        {
        }
        public override bool WithinBounds(Point point)
        {
            if (Math.Sqrt(Math.Pow(point.X - Position.X, 2) + Math.Pow(point.Y - Position.Y, 2)) <= Radius)
                return true;
            else
                return false;
            // Note, if statement could be removed to become the below:
            //return Math.Sqrt(Math.Pow(point.X - Position.X, 2) + Math.Pow(point.Y - Position.Y, 2)) <= Radius;
        }
    }
