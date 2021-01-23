    static IEnumerable<QueryFlag> GetFlags(QueryFlag flags)
    {
        foreach (QueryFlag flag in Enum.GetValues(typeof(QueryFlag)))
        {
            // Presumably you don't want to include None.
            if (flag == QueryFlag.None)
            {
                continue;
            }
            if ((flags & flag) == flag)
            {
                yield return flag;
            }
        }
    }
