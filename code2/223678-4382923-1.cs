    public class SystemClock
    {
        protected DateTime _start;
        public SystemClock()
        {
            this._start = DateTime.UtcNow;
        }
        public virtual Int32 getSystemTime()
        {
            return Convert.ToInt32(Math.Floor(DateTime.UtcNow.Subtract(this._start).TotalSeconds));
        }
    }
