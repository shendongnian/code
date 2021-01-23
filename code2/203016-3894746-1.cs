    public class FooEqualityComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return Equals(x.Prop1, y.Prop1);
        }
        public int GetHashCode(Foo x)
        {
            return x.Prop1.GetHashCode();
        }
    }
