        [System.Diagnostics.DebuggerDisplay("Range({Start} - {End})")]
        public class Range : IEnumerable<int>
        {
            public int Start, End;
            public Range(int start, int end)
            {
                Start = start;
                End = end;
            }
            public IEnumerator<int> GetEnumerator()
            {
                for (int i = Start; i <= End; i++)
                    yield return i;
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            { return GetEnumerator(); }
            public IEnumerable<Range> Subtract(IEnumerable<int> removed)
            {
                IEnumerator<int> add = this.GetEnumerator();
                IEnumerator<int> rem = removed.GetEnumerator();
                bool hasmore = rem.MoveNext();
                while (add.MoveNext())
                {
                    int start = add.Current;
                    int end = start;
                    while (hasmore && rem.Current < start)
                        hasmore = rem.MoveNext();
                    if(!hasmore)
                    {
                        while (add.MoveNext())
                            end = add.Current;
                        yield return new Range(start, end);
                        yield break;
                    }
                    if(rem.Current == start)
                    {
                        hasmore = rem.MoveNext();
                        continue;
                    }
                    while (add.MoveNext())
                    {
                        if (add.Current == rem.Current)
                        {
                            hasmore = rem.MoveNext();
                            break;
                        }
                        end = add.Current;
                    }
                    if (end >= start)
                        yield return new Range(start, end);
                }
            }
        }
        public static IEnumerable<int> UnionRanges(this IEnumerable<Range> ranges)
        {
            int pos = int.MinValue;
            foreach(Range r in ranges.OrderBy(x => x.Start))
            {
                pos = Math.Max(pos, r.Start);
                for (; pos <= r.End; pos++)
                    yield return pos;
            }
        }
        public static IEnumerable<Range> CreateRanges(this IEnumerable<int> values)
        {
            Range r = null;
            foreach (int val in values)
            {
                if (r == null)
                    r = new Range(val, val);
                else if (val == r.End + 1)
                    r.End++;
                else
                {
                    yield return r;
                    r = new Range(val, val);
                }
            }
            if (r != null)
                yield return r;
        }
        public static void Main()
        {
            Range range1 = new Range(0, 100);
            Range range2 = new Range(40, 60);
            IEnumerable<Range> diff1 = range1.Subtract(range2);
            Console.WriteLine("Subtract 40-60 from 0-100:");
            foreach (Range r in diff1)
                Console.WriteLine("{0} ~ {1}", r.Start, r.End);
            List<Range> rangeSet = new List<Range>();
            rangeSet.Add(new Range(10, 30));
            rangeSet.Add(new Range(25, 70));
            rangeSet.Add(new Range(90, 120));
            Console.WriteLine("Normalized ranges to remove:");
            foreach (Range r in rangeSet.UnionRanges().CreateRanges())
                Console.WriteLine("{0} ~ {1}", r.Start, r.End);
            IEnumerable<Range> diff2 = range1.Subtract(rangeSet.UnionRanges());
            Console.WriteLine("Results:");
            foreach (Range r in diff2)
                Console.WriteLine("{0} ~ {1}", r.Start, r.End);
        }
