    class BaseClass<T, K> where T : BaseClass<T, K>
    {
        protected static K _secret;
        public static K Secret { get { return _secret; } }
    }
    class Derived : BaseClass<Derived, int>
    {
        static Derived()
        {
            _secret = 10;
        }
    }
