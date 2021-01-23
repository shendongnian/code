    public class MyStructComparer : IEqualityComparer<MyStruct>
    {
        public bool Equals(MyStruct x, MyStruct y)
        {
            return x.MyVal.Equals(y.MyVal);
        }
        public int GetHashCode(MyStruct obj)
        {
            return obj.MyVal.GetHashCode();
        }
    }
