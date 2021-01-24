    class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box(10, 15);
            Console.WriteLine("Area is: " + box.CalculateArea());
            Console.WriteLine("Perimeter is: " + box.CalculatePerimeter());
            Console.ReadLine();
        }
    }
    public class Box
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Box(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int CalculateArea()
        {
            return Width * Height;
        }
        public int CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }
    }
