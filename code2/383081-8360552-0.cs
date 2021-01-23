        static void Main(string[] args)
        {
            Test<object>();
        }
        static void Test<T>()
        {
            var oType = typeof (object);
            var genericType = typeof (T);
            var equal = oType.Equals(genericType); // equal is 'true'
        }
