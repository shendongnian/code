    public class CrazyTime
    {
        public TimeSpan TimeSpanRepresentation { get; set; }
        public CrazyTime(TimeSpan timeSpan)
        {
            this.TimeSpanRepresentation = timeSpan;
        }
        public CrazyTime(string crazyTime)
        {
            // No error checking. Add if so desired
            var pieces = crazyTime.Split(new[] { ':' });
            var minutes = int.Parse(pieces[0]);
            var seconds = int.Parse(pieces[1]);
            TimeSpanRepresentation = new TimeSpan(0, minutes, seconds);
        }
        public static CrazyTime operator-(CrazyTime left, CrazyTime right)
        {
            var newValue = left.TimeSpanRepresentation - right.TimeSpanRepresentation;
            return new CrazyTime(newValue);
        }
        public override string ToString()
        {
            // How should negative Values look?
            return ((int)Math.Floor(TimeSpanRepresentation.TotalMinutes)).ToString() + ":" + TimeSpanRepresentation.Seconds.ToString();
        }
    }
