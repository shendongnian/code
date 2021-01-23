    class WeekdayException : ApplicationException
    {
        private readonly string _message;
    
        public override string Message
        {
            get { return _message; }
        }
    
        public WeekdayException(String wday)
        {
            _message = "Illegal weekday: " + wday;
        }
    
        public override string ToString()
        {
            return Message;
        }
    }
