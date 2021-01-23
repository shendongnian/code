    public class WellKnownTimeSpan : WellKnownBase<TimeSpan>
    {
        protected override int Convert(TimeSpan input) 
        { 
            return (int)input.TotalMilliseconds; 
        }
    }
