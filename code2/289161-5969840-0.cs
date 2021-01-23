    public class MyObject
    {
        public int Number { get; set; }
    }
    public class MyObjectComparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(MyObject obj)
        {
            return obj.Id.GetHashCode();
        }
    }
