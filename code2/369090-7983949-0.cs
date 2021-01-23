    class Program
    {
        static void Main(string[] args)
        {
            LoadMarkers();
            var location = new Point(45, 45);
            Marker top = markerAtLocation(new Point(location.X, location.Y + 1));
            if (top == null)
                Console.WriteLine("Top is null");
            else
                Console.WriteLine("Top is " + top.ToString());
            Marker bottom = markerAtLocation(new Point(location.X, location.Y - 1));
            
        }
        public static List<Marker> Markers = new List<Marker>();
        private static void LoadMarkers()
        {
            for (var q = 0; q < 50; q++)
                for (var w = 0; w < 50; w++)
                    Markers.Add(new Marker(q, w));
        }
        public static Marker markerAtLocation(Point location)
        {
            foreach (Marker nextMarker in Markers)
                if (nextMarker.Location().Equals(location))
                    return nextMarker;
            return null;
        }
    }
    class Marker
    {
        private Point _loc;
        public Marker(int x, int y) { _loc = new Point(x, y); }
        public Point Location() { return _loc; }
    }
    class Point
    {
        public int X, Y;
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public bool Equals(Point anotherPoint)
        {
            return ((anotherPoint.X == X) && (anotherPoint.Y == Y));
        }
    }
