    public enum SType
    {
        A,
        B,
        C,
        D
    }
    public class Schedule : Register
    {
        public SType Type { get; set; }
        public Schedule(int from, int to, SType type) : base(from, to)
        {
            Type = type;
        }
    }
    public class Register
    {
        public int From { get; set; }
        public int To { get; set; }
        public int TotalHours => To - From;
        public Register(int from, int to)
        {
            From = from;
            To = to;
        }
    }
