    class WeekdayException : ApplicationException {
        private readonly string weekday;
        public WeekdayException(String wday) : base("Illegal weekday: " + wday) {
            this.weekday = wday;
        }
    
        public override string ToString()
        {
            return "HELLO " + this.weekday;
        }
    }
