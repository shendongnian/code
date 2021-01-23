    sealed class PersonId
    {
        readonly int value;
        public int Value { get { return value; } }
    
        public PersonId(int value)
        {
            // (you might want to validate 'value' here.)
            this.value = value;
        }
    
        // override these in order to get value type semantics:
        public override bool Equals(object other) { … }
        public override int GetHashCode() { … }
    }
