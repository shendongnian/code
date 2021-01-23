    public class A
    {
        protected static void Foo<T>()
        {
            // use typeof(T)
        }
    }
    public class B : A
    {
        public static void Foo()
        {
            A.Foo<B>();
        }
    }
