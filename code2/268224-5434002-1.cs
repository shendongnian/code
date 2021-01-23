    public class SomeClass : IEquatable<SomeClass>
    {
        public bool Equals(SomeClass other)
        {
            // actual compare
        }
    
        public override bool Equals(object other)
        {
            // cross-call to IEquatable's equals.
            return Equals(other as SomeClass); 
        }
    }
