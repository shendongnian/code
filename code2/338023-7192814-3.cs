    static class Foo
    {
        public static IEnumerable<int> f;
        private static IEnumerable<int> Sequence()
        {
            int x = 0;
            while(true) yield return x++;
        }
        public static Bar() { Foo.f = Sequence(); }
    }
