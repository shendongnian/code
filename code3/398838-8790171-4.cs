    public struct MyStruct : IComparable
    {
        public int F { get; set; }
        // other non-sort/search affecting properties
        public int X { get; set; }
        public int CompareTo(object other)
        {
            // if the type is NOT an int, you can decide whether you'd prefer
            // to throw, but the concept of comparing the struct to something
            // unknown shouldn't return a value, should probably throw.
            return F.CompareTo((int)other);
        }
    }
