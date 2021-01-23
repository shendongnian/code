    public class Segment
    {
        private int distance;
        public virtual int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
    }
    public class Line : Segment
    {
        public override int Distance
        {
            get { return base.Distance; }
            set
            {
                // do nothing
            }
        }
    }
