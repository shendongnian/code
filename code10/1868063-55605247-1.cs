    public static bool operator !=(Node<T> f1, Node<T> f2)
    {
        if (object.ReferenceEquals(f1, null))
        {
             return object.ReferenceEquals(f2, null);
        }
        return f1.Value.CompareTo(f2.Value);
    }
