    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(5, 5);
            Point p2 = p1.ShallowCopy();
            p2.x = 1;
            Console.WriteLine("p1.x:{0}-------p2.x:{1}", p1.x , p2.x);
            Console.ReadKey();
        }
    }
    class Point
    {
        public int x { get;set; } 
        public int y { get; set; }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point ShallowCopy()
        {
            return (Point)this.MemberwiseClone();
        }
    }
    }
