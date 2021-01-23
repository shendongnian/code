    public class Shape
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Image Image { get; set; }
    }
    public class Line
    {
        public Shape A { get; set; }
        public Shape B { get; set; }
    }
