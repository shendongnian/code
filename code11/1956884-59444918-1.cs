    public class A<T>
    {
        public class B<T1>: A<T1>
        {
            public static void F(B<T1> i) {}
        }
    }
    A<int>.B<string>.F(new A<string>.B<string>()); // suddenly this compiles
