    public class TimeInterval
    {
        private readonly DateTime _start;
        private readonlyDateTime _end;
    
        public DateTime Start{get{return _start}
        public DateTime End{get{return _end;}
        public TimeSpan Duration{get{return _end-_start;}}
    
        public TimeInterval(DataTime start,DateTime end)
        {
             if(start.Kind!=end.Time)
                throw new ArgumentException("Incompatible DataTimes");
        }
        
        public TimeInterval(DataTime start,TimeSpan duration)
        {
        }
    }
