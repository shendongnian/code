    public class VariableSystemClock : SystemClock
    {
        private TimeSpan _interval;
        public VariableSystemClock(TimeSpan interval)
            : base()
        {
            this._interval = interval;
        }
        public override Int32 getSystemTime()
        {
            Double ellapsed = DateTime.UtcNow.Subtract(this._start).Ticks / this._interval.Ticks;
            return Convert.ToInt32(Math.Floor(ellapsed));
        }
    }
