    struct SuperDateTime
    {
        public DateTime Value;
        public static implicit operator SuperDateTime(DateTime d) { return new SuperDateTime { Value = d }; }
        public static implicit operator SuperDateTime(long x) { return new SuperDateTime { Value = Epoch.AddMilliseconds(x) }; }
        public static implicit operator DateTime(SuperDateTime d) { return d.Value; }
    }
