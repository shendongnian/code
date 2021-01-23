        public interface Base
        {
            DateTime StartTime { get; }
        }
    
        public class Foo : Base
        {
            DateTime start_time_;
    
            public DateTime StartTime
            {
                get { return start_time_; }
                internal set { start_time_ = value; }
            }
        }
