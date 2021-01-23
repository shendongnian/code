    // Note: We are using a generic type constraint on T.
    public static IEnumerable<T> AcceptChangesAndYield<T>(this IEnumerable<T> obj)
        where T : MyModels.Interfaces.ILookup
    {
        if (obj.IsNull()) yield break;
        foreach (var m in obj)
        {
            // Did you mean to put m.AcceptChanges() here?
            yield return m;
        }
    }
