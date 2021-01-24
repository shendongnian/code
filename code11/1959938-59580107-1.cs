        public class SetWithRange : IEnumerable<int>
        {
            private readonly HashSet<int> _values;
            private readonly Range _range;
    
            public SetWithRange(IReadOnlyCollection<int> values)
            {
                _values = new HashSet<int>(values);
                _range = new Range(values);
            }
    
            public static SetWithRange Random(Random random, int size, Range range)
            {
                var values = new HashSet<int>();
    
                // Random.Next(int, int) generates numbers in the range [min, max)
                // so we need to add one here to be able to generate numbers in [min, max].
                // See https://docs.microsoft.com/en-us/dotnet/api/system.random.next
                var min = range.Min;
                var max = range.Max + 1;
    
                while ( values.Count() < size )
                    values.Add(random.Next(min, max));
    
                return new SetWithRange(values);
            }
    
            public int CommonValuesWith(SetWithRange other)
            {
                // No need to call Intersect on the sets if the ranges don't intersect
                if ( !_range.Intersects(other._range) )
                    return 0;
    
                return _values.Intersect(other._values).Count();
            }
    
            public IEnumerator<int> GetEnumerator()
            {
                return _values.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
