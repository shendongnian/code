    for (var en = Constrains.GetEnumerator(); en.MoveNext(); )
    {
        var c = en.Current;
        if (!c.Allows(a))
        {
            a.Change();
            en = Constrains.GetEnumerator();
        }
    }
