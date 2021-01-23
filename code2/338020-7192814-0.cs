    static class Foo
    {
        public static Func<int> f;
        public static void Bar()
        {
            int x = 0;
            Foo.f = ()=>{ return x++; };
        }
    }
