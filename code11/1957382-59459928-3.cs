    public class Foo<T1, T2, T3>
    {
        T1 t1;
        T2 t2;
        T3 t3;
        public Foo(T1 t1, T2 t2, T3 t3)
        {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
        }
        public TOut Bar<TOut>()
        {
            ...
        }
    }
    public class Foo
    {
        public static Foo<T1, T2, T3> CreateFoo<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return new Foo<T1, T2, T3>(t1, t2, t3);
        }
    }
