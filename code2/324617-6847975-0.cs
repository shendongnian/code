    public struct VagueDate
    {
        DateTime start, end;
        public DateTime Start { get { return start; } }
        public DateTime End { get { return end; } }
        public TimeSpan Span { get { return end - start; } }
        public VagueDate(string Date)
        {
            if (DateTime.TryParseExact(Date, "yyyy", null, 0, out start))
                end = start.AddYears(1);
            else if (DateTime.TryParseExact(Date, "MM/yyyy", null, 0, out start))
                end = start.AddMonths(1);
            else if (DateTime.TryParseExact(Date, "dd/MM/yyyy", null, 0, out start))
                end = start.AddDays(1);
            else
                throw new ArgumentException("Invalid format", "Date");
        }
        public override string ToString()
        {
            return Start.ToString("dd/MM/yyyy") + " plus " + Span.TotalDays + " days";
        }
    }
