    public struct HiResDateTime
    {
        public HiResDateTime(DateTime dateTime, int nanoseconds)
        {
            if (nanoSeconds < 0 || nanoSeconds > 99) 
                throw new ArgumentOutOfRangeException(...);
            DateTime = dateTime;
            Nanoseconds = nanoseconds;
        }
        ... possibly other constructors including one that takes a timestamp parameter
        ... in the format provided by the instruments.
        public DateTime DateTime { get; private set; }
        public int Nanoseconds { get; private set; }
        ... implementation ...
    }
