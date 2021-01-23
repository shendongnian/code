    public sealed class Foo
    {
        private readonly string something;
        private readonly Foo other; // might be null
        public Foo(string s)
        {
            something = s;
            other = null;
        }
        public Foo(string s, Foo a)
        {
            something = s;
            other = a;
        }
        public Foo(string s, string s2)
        {
            something = s;
            other = new Foo(s2, this);
        }
    }
