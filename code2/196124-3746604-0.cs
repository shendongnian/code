    private IEnumerable<QueryFlag> GetFlags()
    {
        foreach (QueryFlag flag in Enum.GetValues(typeof(QueryFlag)))
        {
            // Presumably you don't want to include None.
            if (flag == QueryFlag.None)
            {
                continue;
            }
            if ((qFlag & flag) == flag)
            {
                yield return flag;
            }
        }
    }
