    IEnumerable<T> items = ...;
    using (var enumerator = items.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            T first = enumerator.Current;
            bool hasSecond = enumerator.MoveNext();
            Trace.Assert(hasSecond, "Collection must have even number of elements.");
            T second = enumerator.Current;
            var tuple = new Tuple<T, T>(first, second);
            //Now you have the tuple
        }
    }
