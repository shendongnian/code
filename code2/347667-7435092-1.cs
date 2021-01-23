    class MyTypeIdComparer : IEqualityComparer<MyType>
    {
        public bool Equals(MyType x, MyType y)
        {
            return x.Id.CompareTo(y.Id);
        }
        public int GetHashCode(MyType obj)
        {
            return obj.Id.GetHashCode();
        }
    }
