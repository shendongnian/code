    public class A<T>
    {
        public static void Foo()
        {
            // use typeof(T)
        }
    }
    public class B : A<B>
    {
    }
