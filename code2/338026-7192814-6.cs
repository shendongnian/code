    static class Foo
    {
        private static Func<int> f;
        public static int Bar()
        {
            if (Foo.f == null)
            {
               int x = 0;
               Foo.f = ()=>{ return x++; };
            }
            return Foo.f();
        }
    }
