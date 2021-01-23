    // Probably you'd make this implement IEquatable<Term>, IEquatable<double>, etc.
    // Probably you'd also give it a more descriptive, less ambiguous name.
    // Probably you also just flat-out wouldn't use it at all.
    struct Term
    {
        readonly double _value;
        
        internal Term(double value)
        {
            _value = value;
        }
        
        public override bool Equals(object obj)
        {
            // You would want to override this, of course...
        }
        
        public override int GetHashCode()
        {
            // ...as well as this...
            return _value.GetHashCode();
        }
        
        public override string ToString()
        {
            // ...as well as this.
            return _value.ToString();
        }
    }
