    class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }        
    }
    
    class Dot
    {
        public Coordinate coord { get; private set; }
        public string color { get; set; }
        public Dot(string color, Coordinate coord)
        {
            this.color = color;
            this.coord = coord;
    
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate coor1 = new Coordinate(2, 3);
            Dot dot1 = new Dot("Blue", coor1);
		    Console.WriteLine(dot1.coord.X);        
        }
    }
