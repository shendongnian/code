        public class Range
        {
            private readonly int _min;
            private readonly int _max;
    
            public Range(IReadOnlyCollection<int> values)
            {
                _min = values.Min();
                _max = values.Max();
            }
    
            public int Min { get { return _min; } }
            public int Max { get { return _max; } }
    
            public bool Intersects(Range other)
            {
                if ( _min < other._max )
                    return false;
    
                if ( _max > other._min )
                    return false;
    
                return true;
            }
        }
    
