    public class Clock
    {
        public const int HourPerDay = 24;
        public const int MinutesPerHour = 60;
        public const int MinutesPerDay = MinutesPerHour * HourPerDay;
        private int totalMinutes;
        public int Minute
        {
            get { return this.totalMinutes % MinutesPerHour; }
        }
        public int Hour
        {
            get { return this.totalMinutes / MinutesPerHour; }
        }
        public void AddMinutes(int minutes)
        {
            this.totalMinutes += minutes;
            this.totalMinutes %= MinutesPerDay;
            if (this.totalMinutes < 0)
                this.totalMinutes += MinutesPerDay;
        }
        public void AddHours(int hours)
        {
            this.AddMinutes(hours * MinutesPerHour);
        }
        public override string ToString()
        {
            return string.Format("{0:00}:{1:00}", this.Hour, this.Minute);
        }
    }
