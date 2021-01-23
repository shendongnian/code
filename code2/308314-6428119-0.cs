    public struct Foo
    {
        public int Bar;
        public static bool operator ==(Foo a, Foo b)
        {
            return a.Bar == b.Bar;
        }
        public static bool operator !=(Foo a, Foo b)
        {
            return !(a.Bar == b.Bar);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
