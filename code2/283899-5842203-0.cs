    public override bool Equals(SomeKey<T,V> otherKey)
    {
        return (Value1==otherKey.Value1) & (Value2==otherKey.Value2);
    }
    public override int GetHashCode()
    {
        return Value1.GetHashCode() ^ Value2.GetHashCode();
    }
