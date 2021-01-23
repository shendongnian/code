    public class MyClass
    {
        public static class C&lt;T>
        {
            public static Func&lt;IList&lt;T>, T> SelectElement
            {
                get { return xs => xs.First(); }
            }
        }
        public object Test(IList&lt;object> list)
        {
            return C&lt;object>.SelectElement(list);
        }
    }
