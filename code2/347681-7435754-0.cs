    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }
        public IList<Range> Exclude(Range r)
        {
            if (r.Start <= Start && r.End < End)
            {
                return new List<Range>{new Range { Start = r.End + 1, End = End }};
            }
            else if (r.Start > Start && r.End >= End)
            {
                return new List<Range>{new Range { Start = Start, End = r.Start - 1 }};
            }
            else if (r.Start > Start && r.End < End)
            {
                return new List<Range>
                           {
                               new Range { Start = Start, End = r.Start - 1 },
                               new Range { Start = r.End + 1, End = End }
                           };
            }
            return new List<Range>();
        }
    }
    // ...
    static void Main(string[] args)
    {
        Range r = new Range { Start = 1, End = 20};
        var list = r.Exclude(new Range{ Start = 1, End = 2} );
    }
