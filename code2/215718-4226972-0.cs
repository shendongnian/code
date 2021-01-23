    class Foo
    {
        public Foo(int v)
        {
            this.v = v;
        }
        int v;
        public int Multiply(int x)
        {
            return v * x;
        }
        public int Add(int x)
        {
            return v+x;
        }
        delegate int NewFunctionPointer(Foo, int);
        delegate int OldDelegateStyle(int);
        static void Example()
        {
             Foo f = new Foo(2);
             Foo f2 = new Foo(3);
             // instead of this, which binds an instance
             OldDelegateStyle oldMul = f.Multiply;
             // You have to use this
             NewFunctionPointer mul = delegate(Foo f, int x) { return f.Multiply(x); }
             NewFunctionPointer add = delegate(Foo f, int x) { return f.Add(x); }
             // But can now do this
             mul(f, 4); // = 8
             add(f2, 1); // = 3
        }
    }
