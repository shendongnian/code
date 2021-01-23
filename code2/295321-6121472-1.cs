    class EnumComparer : IComparer<Enum>
    {
        public int Compare(Enum x, Enum y)
        {
            return x.GetHashCode() - y.GetHashCode();
        }
    }
    var sorted = new SortedList<Enum, MyEnum>(new EnumComparer());
