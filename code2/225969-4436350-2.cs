    public class Foo : IEquatable<Foo>
    {
        public bool Equals(Foo other)
        {
            if (other == null)
                return false;
            if (other == this)
                return true; // Same object reference.
    
            // Compare this to other and return true/false as appropriate.
        }
    
        public override bool Equals(Object other)
        {
            return Equals(other as Foo);
        }
    
        public override int GetHashCode()
        {
            // Compute and return hash code.
        }
    }
