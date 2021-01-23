    public class MyClass {
        private bool isTrue = true;
        public static bool operator ==(MyClass a, bool b)
        {
            if (a == null)
            {
                return false;
            }
            return a.isTrue == b;
        }
        public static bool operator !=(MyClass a, bool b)
        {
            return !(a == b);
        }
    }
