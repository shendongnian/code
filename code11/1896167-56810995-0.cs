    public class A : IEquatable<A>
    {
        public string Prop { get; }
        public A(string val)
        {
            Prop = val;
        }
        public bool Equals(A other)
        {
            if (other == null) return false;
            return Prop == other.Prop;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as A);
        }
        public override int GetHashCode()
        {
            return Prop.GetHashCode();
        }
    }
    public class B : IEquatable<B>
    {
        public IReadOnlyList<A> Prop { get; }
        public B(IReadOnlyList<A> val)
        {
            Prop = val;
        }
        public bool Equals(B other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Prop == null) return other.Prop == null;
            return other.Prop != null && Prop.SequenceEqual(other.Prop);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as B);
        }
        public override int GetHashCode()
        {
            return Prop?.Aggregate(17,
                (current, item) => current * 17 + item?.GetHashCode() ?? 0)
                    ?? 0;
        }
    }
