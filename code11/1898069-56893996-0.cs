    class Box
        {
            public int Length { get; set; }
            public int Height { get; set; }
            public int Width { get; set; }
            public int Volume => Length * Width * Height;
            public void DisplayBox()
            {
                Console.WriteLine("The height of box is length {0} * height {1} * width {2} and volume is {3}", Length, Height, Width, Volume);
            }
            public Box(){}
            public Box(int length, int height, int width)
            {
                Length = length;
                Height = height;
                Width = width;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                //Using custom constructor
                new Box(5,10,4).DisplayBox();
                //Using default constructor
                new Box {Length = 5, Height = 10, Width = 4}.DisplayBox();
                //Using class instance
                var box = new Box();
                box.Length = 5;
                box.Height = 10;
                box.Width = 4;
                box.DisplayBox();
                Console.ReadKey();
            }
        }
