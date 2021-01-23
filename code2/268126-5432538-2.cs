    class BasicClass : IEquatable<BasicClass>
    {
        public Name {get;set;}
        public Age {get;set;}
    
        public bool Equals(BasicClass other)
        {
            if (other == null)
                return false;
            return string.Equals(this.Name, other.Name);
        }
        public override int GetHashCode()
        {
            return Name == null ? 0 : Name.GetHashCode();
        }
    }
