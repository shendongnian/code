    public class Foo : IEquatable<Foo>
    {
        public virtual bool Equals(Foo other)
        {
            return true;
        }
    }
    public class A : Foo,IEquatable<A>
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public override bool Equals(Foo other)
        {
            if (other.GetType() == typeof(A))
            {
                return Equals((A)other);                
            }
            throw new InvalidOperationException("Object is not of type A");
        }
        public bool Equals(A other)
        {
            return this.Number1 == other.Number1 && this.Number2 == other.Number2;
        }
    }
    public class B : Foo,IEquatable<B>
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public override bool Equals(Foo other)
        {
            if (other.GetType() == typeof(B))
            {
                return Equals((B)other);
                
            }
            throw new InvalidOperationException("Object is not of type B");
        }
        public bool Equals(B other)
        {
            return this.Number1 == other.Number1 && this.Number2 == other.Number2 && this.Number3 == other.Number3;
        }
    }
