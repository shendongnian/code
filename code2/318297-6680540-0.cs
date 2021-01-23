    public bool Equals(Car x, Car y)
    {
        return x != null && y != null && x.Id == y.Id;
    }
    public int GetHashCode(Car obj)
    {
        return obj == null ? 0 : obj.Id;
    }
}
