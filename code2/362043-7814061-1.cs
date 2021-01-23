    struct DateRange
    {
        private readonly DateTime start;
        private readonly DateTime end;
        public DateRange(DateTime start, DateTime end)
        {
            this.start = start.Date;
            this.end = end.Date;
        }
        public DateTime Start
        {
            get
            {
                return this.start;
            }
        }
        public DateTime End
        {
            get
            {
                return this.end;
            }
        }
        public static bool operator ==(DateRange dateRange1, DateRange dateRange2)
        {
            return dateRange1.Equals(dateRange2);
        }
        public static bool operator !=(DateRange dateRange1, DateRange dateRange2)
        {
            return !dateRange1.Equals(dateRange2);
        }
        public override int GetHashCode()
        {
            // Overflow is fine, just wrap
            unchecked
            {
                var hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = (23 * hash) + this.start.GetHashCode();
                hash = (23 * hash) + this.end.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return (obj is DateRange)
                && this.start.Equals(((DateRange)obj).Start)
                && this.end.Equals(((DateRange)obj).End);
        }
    }
