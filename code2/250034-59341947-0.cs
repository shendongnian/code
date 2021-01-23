    public class MyComparer : IEqualityComparer<MyModel>
    {
        public bool Equals(MyModel x, MyModel y)
        {
           // compare multiple fields
            return
                x.Field1 == y.Field1 &&
                x.Field2 == y.Field2 &&
                x.Field3 == y.Field3 ;
        }
    
        public int GetHashCode(MyModel obj)
        {
            return (int)obj.Field1;
        }
    }
