        public EpochBasedDateTime(DateTime value) => Value = value;
        public EpochBasedDateTime(int milliseconds)
            : this(Epoch.addMilliseconds(milliseconds)
        {
        }
        public static readonly DateTime Epoch = new DateTime(1970,1,1);
        public DateTime Value {get;}
        public static implicit operator EpochBasedDateTime (int milliseconds)
           => new EpochBasedDateTime(milliseconds);
        public static implicit operator DateTime (EpochBasedDateTime date)
           => date.Value;
    }
