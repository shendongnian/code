    using (IEnumerator<Foo> iterator = myDict.Values.GetEnumerator())
    {
        while (iterator.MoveNext())
        {
            object obj = iterator.Current;
            // Body
        }
    }
