    class MyComparer : IEqualityComparer<MyObj>
    {
        public bool Equals(MyObj x, MyObj y)
        {
            return x.GetId() == y.GetId();
        }
        public int GetHashCode(MyObj obj)
        {
            return obj.GetId();
        }
    }
    var resultList = refList1.Union(refList2, new MyComparer()).ToList();
