        public abstract class Segment
        {            
            public abstract int Distance { get; set; }
        }
        public class Line : Segment
        {
            private int distance;
            public override int Distance
            {
                get { return distance; }
                set
                {
                    // do nothing
                }
            }
        }
