    using (IEnumerator<Foo> iterator = CachedEnumerable.GetEnumerator())
    {
        while (iterator.MoveNext())
        {
            var d = iterator.Current;
            // Other loop
        }
    }
