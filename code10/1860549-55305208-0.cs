    class Coordinate
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;
        public Coordinate(int x, int y)
        {
            x = X;
            y = Y;
        }        
    }
    
    class Dot
    {
        private Coordinate coord { get; set; }
        public string color { get; set; }
        public Robot(string color, Coordinate coord)
        {
            this.Color = color;
            this.coord = coord;
    
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate coor1 = new Coordinate(2, 3);
            Dot dot1 = new Dot("Blue", coor1);        
        }
    }
