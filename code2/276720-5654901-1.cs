    public static IEnumerable<TBase> Cast<TDerived, TBase>
        (IEnumerable<TDerived> source)
        where TDerived : TBase
    {
        foreach (TDerived item in source)
        {
            yield return item;
        }
    }
