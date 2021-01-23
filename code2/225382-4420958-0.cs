    using System;
    
    public sealed class Foo : IEquatable<Foo>
    {
        private readonly string name;
        public string Name { get { return name; } }
        
        private readonly int value;
        public int Value { get { return value; } }
        
        public Foo(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
        
        public override bool Equals(object other)
        {
            return Equals(other as Foo);
        }
        
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + (name == null ? 0 : name.GetHashCode());
            hash = hash * 31 + value;
            return hash;
        }
        
        public bool Equals(Foo other)
        {
            if ((object) other == null)
            {
                return false;
            }
            return name == other.name && value == other.value;
        }
        
        public static bool operator ==(Foo left, Foo right)
        {
            return object.Equals(left, right);
        }
        
        public static bool operator !=(Foo left, Foo right)
        {
            return !(left == right);
        }
    }
