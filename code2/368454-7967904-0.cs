    class LookupKey: IComparable<LookupKey>
    {
        public int IntValue1 { get; private set; }
        public int IntValue2 { get; private set; }
        public bool BoolValue1 { get; private set; }
        public LookupKey(int i1, int i2, bool b1)
        {
            // assign values here
        }
        public int Compare(LookupKey k1, LookupKey k2)
        {
            return k1.IntValue1 == k2.IntValue1 &&
                   k1.IntValue2 == k2.IntValue2 &&
                   k1.BoolValue1 == k2.BoolValue1;
        }
        public int GetHashCode()
        {
            return (19 * IntValue1) + (1000003 * IntValue2) + (BoolValue1) ? 0 : 100000073;
        }
        // need to override Equals
    }
