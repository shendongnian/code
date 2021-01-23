    public class Segment
    {
        protected int _distance;
        public int Distance { get { return _distance; } }
    }
    
    public class Line : Segment
    {
        public int SetDistance(int distance) { _distance = distance; }
    }
