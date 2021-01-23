    public struct RecordValue
    {
        private object _ref;
        private long _val;
        public string String
        {
            get { return _ref as string; }
            set { _ref = value; }
        }
        public double Double 
        { 
            get { return BitConverter.Int64BitsToDouble(_val); }
            set { _val = BitConverter.DoubleToInt64Bits(value); }
        }
        public long Int64
        {
            get { return _val; }
            set { _val = value; }
        }
        public ulong UInt64
        {
            get { return unchecked((ulong)_val); }
            set { _val = unchecked((long)value); }
        }
        public int Int32
        {
            get { return unchecked((int)_val); }
            set { _val = value; }
        }
    }
