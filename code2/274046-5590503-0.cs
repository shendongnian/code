    class Foo
    {
        private int _bar;
        public int Bar
        {
            get { return _bar; }
            set { _bar = value + 1; }
        }
    }
    ...
    Foo foo = new Foo();
    int a, c;
    c = 4;
    a = foo.Bar = c; // is 'a' 4 or 5? 
