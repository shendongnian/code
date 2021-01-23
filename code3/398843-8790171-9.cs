    public struct MyStruct 
    {
        public int F { get; set; }
        // other non-sort/search affecting properties
        public int X { get; set; }
    }
    public struct MyStructComparer : IComparer<MyStruct>
    {
        public int Compare(MyStruct x, MyStruct y)
        {
            return x.F.CompareTo(y.F);
        }
    }
