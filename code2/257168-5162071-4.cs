    using (var e = collection.GetEnumerator())
    {
        if (e.MoveNext())
        {
            var firstItem = e.Current;
            // add logic here
        }
    }
