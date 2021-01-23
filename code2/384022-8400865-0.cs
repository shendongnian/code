    public class WrapperComparer : IEqualityComparer<MyObject>
    {
        private IDictionary<string, IEqualityComparer<MyObject>> _myComparerList;
        public bool Equals(MyObject x, MyObject y)
        {
            var comparer = _myComparerList[x.SomeProperty];
            return comparer.Equals(x, y);
        }
        public bool GetHashCode(MyObject obj)
        {
            var comparer = _myComparerList[obj.SomeProperty];
            return comparer.GetHashCode(obj);
        }
    }
