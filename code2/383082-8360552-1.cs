        static void Main(string[] args)
        {
            Test<object>();
        }
        static object Test<T>()
        {
            var currentMethod = ((MethodInfo) MethodBase.GetCurrentMethod());
            var oType = currentMethod.ReturnType;
            var genericType = typeof (T);
            var equal = oType.Equals(genericType); // result is true.
            return null;
        }
