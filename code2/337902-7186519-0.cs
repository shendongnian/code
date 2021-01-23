    public class TestClassWrapper<T> where T : TestClass
    {
        private static readonly FieldInfo field = typeof(T).GetField("x");
        public int test()
        {
            return (int) field.GetValue(null);
        }
    }
