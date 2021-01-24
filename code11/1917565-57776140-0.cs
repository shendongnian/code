    public class MyComparer : IEqualityComparer<object>
    {
        public bool Equals(object o1, object o2)
        {
            // implement your way of equality 
        }
        public int GetHashCode(object o)
        {
            // implement a hash method that returns equal hashes for equal
            // objects and well distributed hashes for not-equal objects
        }
    }
    Dictionary<object, int> myDict = new Dictionary<object, int>(new MyComparer());
