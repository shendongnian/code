    class Program
    {
        static void Main(string[] args)
        {
            // could actually be anything else
            Type myType = typeof(string);
            Type myArrayType = Array.CreateInstance(myType, 1).GetType();
            // i already know all the elements are the correct types
            object[] myArray = new object[] { "foo", "bar" };
            MethodInfo castMethod = typeof(Enumerable).GetMethod("Cast").MakeGenericMethod(myArrayType);
            object castedObject = castMethod.Invoke(null, new object[] { myArray });
        }
        public static T Cast<T>(object o)
        {
            return (T)o;
        }
    }
