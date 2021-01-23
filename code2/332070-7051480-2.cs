    public class A : Foo, IEquatable<A>
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    
        public bool Equals(A other)
        {
            return other != null 
                && Number1 == other.Number1
                && Number2 == other.Number2;
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as A);
        }
    
        public override int GetHashCode()
        {
            return Number1 ^ Number2;
        }
    }
