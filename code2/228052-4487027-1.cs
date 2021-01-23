    ICollection<Foo> foos = ...
    using (var erator = foos.GetEnumerator())
    {
        if (!erator.MoveNext())
            return;
        var current = erator.Current;
        while (erator.MoveNext())
        {
            ProcessNormalItem(current);
            current = erator.Current;
        }
        ProcessLastItem(current);
    }
