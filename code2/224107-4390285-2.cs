    using (var erator = enumerable.GetEnumerator())
    {
        if (erator.MoveNext())
        {
            ProcessFirst(erator.Current);
            //ProcessOther(erator.Current) // Include if appropriate.
    
            while (erator.MoveNext())
                ProcessOther(erator.Current);
        }
    }
