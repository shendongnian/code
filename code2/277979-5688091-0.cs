    public class Point
    {
        public double X, Y;
        [XmlIgnore]
        public Page Parent;
    }
    public class Line
    {
        public Point StartPoint;
        public Point EndPoint;
        [XmlIgnore]
        public Page Parent;
    }
