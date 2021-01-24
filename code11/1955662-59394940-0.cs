    using (IEnumerator<Test> iterator = list.GetEnumerator())
    {
        while (iterator.MoveNext())
        {
            IDisposable item = (IDisposable) iterator.Current;
            // Body of foreach loop here
        }
    }
