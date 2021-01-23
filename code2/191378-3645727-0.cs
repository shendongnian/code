    /// <summary>Creates a <see cref="Queue&lt;T&gt;"/> from an enumerable
    /// collection.</summary>
    public static Queue<T> ToQueue<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        return new Queue<T>(source);
    }
    /// <summary>Creates a <see cref="Stack&lt;T&gt;"/> from an enumerable
    /// collection.</summary>
    public static Stack<T> ToStack<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        return new Stack<T>(source);
    }
