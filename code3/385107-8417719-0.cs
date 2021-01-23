    public class SampleEntity
    {
        private DateTime someField;
        private DateTime someOtherDate;
        private readonly IClock _clock;
    
        public SampleEntity(IClock clock)
        {
            _clock = clock;
            someField = clock.Now;
        }
    
        public bool SomeProperty
        {
            get { return someOtherDate < _clock.Now.Date; }
        }
    
        public bool SomeFunction()
        {
            return SomeOtherDate < _clock.Now.Date;
        }
    }
