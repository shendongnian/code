    using (var erator = enumerable.GetEnumerator())
    {
        if (erator.MoveNext())
        {
            ProcessFirst(erator.Current);
    
            while (erator.MoveNext())
                ProcessOther(erator.Current);
        }
    }
