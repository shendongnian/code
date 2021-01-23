    public class Foo
    {
        Object _bar = new Object();
        public Object Bar
        {
            get { return _bar; }
            set { _bar = value ?? new Object(); }
        }
    }
