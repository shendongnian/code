    public bool Equals(Logical other) // Implements IEquatable<Logical>
    {
        return Value.Equals(other.Value);
    }
    public override bool Equals(object obj)
    {
        if (obj is Logical logical) {
            return Equals(logical);
        }
        return base.Equals(obj);
    }
    public override int GetHashCode() => Value.GetHashCode();
