    public sealed class RangeCombiner
    {
        public void Include(long start, long end)
        {
            _boundaries.Add(new Boundary(start, isStart: true, isIncluded: true));
            _boundaries.Add(new Boundary(end, isStart: false, isIncluded: true));
            _sorted = false;
        }
        public void Exclude(long start, long end)
        {
            _boundaries.Add(new Boundary(start, isStart: true, isIncluded: false));
            _boundaries.Add(new Boundary(end, isStart: false, isIncluded: false));
            _sorted = false;
        }
        public void Clear()
        {
            _boundaries.Clear();
        }
        public long TotalIncludedRange()
        {
            sortIfNecessary();
            return totalIncludedRange();
        }
        void sortIfNecessary()
        {
            if (_sorted)
                return;
            _boundaries.Sort();
            _sorted = true;
        }
        long totalIncludedRange()
        {
            int  included = 0;
            int  excluded = 0;
            long start    = 0;
            long total    = 0;
            for (int i = 0; i < _boundaries.Count; ++i)
            {
                if (_boundaries[i].IsStart)     // Starting a region...
                {
                    if (_boundaries[i].IsIncluded)      // Starting an included region...
                    {
                        if (++included == 1 && excluded == 0)       // Starting a new included region,
                            start = _boundaries[i].Value;            // so remember its start time.
                    }
                    else                                // Starting an excluded region...
                    {
                        if (++excluded == 1 && included > 0)        // Ending an included region,
                            total += _boundaries[i].Value - start;   // so add its range to the total.
                    }
                }
                else                            // Ending a region...
                {
                    if (_boundaries[i].IsIncluded)      // Ending an included region...
                    {
                        if (--included == 0 && excluded == 0)       // Ending an included region,
                            total += _boundaries[i].Value - start;   // so add its range to the total.
                    }
                    else                                // Ending an excluded region...
                    {
                        if (--excluded == 0 && included > 0)        // Starting an included region,
                            start = _boundaries[i].Value;            // so remember its start time.
                    }
                }
            }
            return total;
        }
        readonly List<Boundary> _boundaries = new List<Boundary>();
        bool _sorted;
        struct Boundary : IComparable<Boundary>
        {
            public Boundary(long value, bool isStart, bool isIncluded)
            {
                Value      = value;
                IsStart    = isStart;
                IsIncluded = isIncluded;
            }
            public int CompareTo(Boundary other)
            {
                if (this.Value < other.Value)
                    return -1;
                if (this.Value > other.Value)
                    return 1;
                if (this.IsStart == other.IsStart)
                    return 0;
                if (this.IsStart)
                    return -1;
                return 1;
            }
            public readonly long Value;
            public readonly bool IsStart;
            public readonly bool IsIncluded;
        }
    }
