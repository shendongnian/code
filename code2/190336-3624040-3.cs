    class Locals
    {
        public int c;
        public Func<int, int, int> f;
        public int Magic(int x) { return f(x, c); }
    }
    Func<int, int> B(Func<int, int, int> f, int c)
    {
        Locals locals = new Locals();
        locals.f = f;
        locals.c = c;
        return locals.Magic;
    }
