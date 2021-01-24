        public static readonly DateTime Epoch = new DateTime(1970,1,1);
        public DateTime Value {get; set;}
        public static implicit operator EpochBasedDateTime (int milliseconds)
            => new MyDate{Value = Epoch.AddMilliseconds(milliseconds);
        public static implicit operator DateTime (EpochBasedDateTime myDate)
           => myDate.Value;
    }
