    public class TestClass
    {
        ...
        public static bool operator !=(TestClass left, TestClass right)
        {
            return !left.Equals(right);
        }
    }
