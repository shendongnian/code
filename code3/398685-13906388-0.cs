    public sealed class MyClass : IEquatable<MyClass>
    {
        Guid m_id = Guid.NewGuid();
        public Guid Id { get { return m_id; } }
        public bool Equals(MyClass other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (ReferenceEquals(null, other))
                return false;
            return Id == other.Id; 
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as MyClass);
        }
        public static bool operator ==(MyClass lhs, MyClass rhs)
        {
            if (ReferenceEquals(lhs, null))
                return ReferenceEquals(rhs, null);
            return lhs.Equals(rhs);
        }
        public static bool operator !=(MyClass lhs, MyClass rhs)
        {
            return !(lhs == rhs);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }	
    }
