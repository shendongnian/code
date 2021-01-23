    public abstract class Base
    {
        public abstract DateTime StartTime { get; internal set; }
    }
    public class Foo : Base
    {
        DateTime start_time_;
        public override DateTime StartTime
        {
            get
            { 
                return start_time_; 
            }
            internal set
            {
                start_time_ = value;
            }
        }
    } 
