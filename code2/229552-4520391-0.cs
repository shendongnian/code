    public class MyObjectComparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject a, MyObject b)
        {
            // code to determine equality, usually based on one or more properties
        }
    
        public int GetHashCode(MyObject a)
        {
            // code to generate hash code, usually based on a property
        }
    }
    // ...
    var distinctItems = myList.Distinct(new MyObjectComparer());
