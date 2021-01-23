    public override bool Equals(SomeKey<T,V> otherKey)
    {
        return Value1.Equals(otherKey.Value1) & Value2.Equals(otherKey.Value2);
    }
    public override int GetHashCode()
    {
        return Value1.GetHashCode() ^ Value2.GetHashCode();
    }
