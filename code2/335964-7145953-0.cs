    public void GetHashCode(T value)
    {
       return ((object)value).GetHashCode();
    }
    public void Equals(T first, T second)
    {
       return ((object)first).Equals((object)second);
    }
