    struct Maybe<T>
    {
        public T Item { get; private set; }
        public bool Valid { get; private set; }
        public Maybe(T item) : this() 
        { this.Item = item; this.Valid = true; }
    }
    public static Maybe<T> MyFirst<T>(this IEnumerable<T> sequence) 
    {
        foreach(T item in sequence)
            return new Maybe(item);
        return default(Maybe<T>);
    }
    ...
    var first = sequence.MyFirst();
    if (first.Valid) Console.WriteLine(first.Item);
