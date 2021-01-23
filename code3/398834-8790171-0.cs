    // using IComparable<T>
    public struct MyStruct : IComparable<MyStruct>
    {
        public int F { get; set; }
        // other fields that should not affect "search"
        public int X { get; set; }
        public int CompareTo(MyStruct other)
        {
            return F.CompareTo(other.F);
        }
    }
