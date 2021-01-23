    public abstract class ObjectThatHasPosition : ICloneable
    {
        public Point CurrentPosition { get; set; }
        public ObjectThatHasPosition(Point p)
        {
            CurrentPosition = p; 
        }
        public object Clone()
        {
            var clone = (ObjectThatHasPosition) MemberwiseClone();
            clone.CurrentPosition = (Point) CurrentPosition.Clone();
        }
    }
