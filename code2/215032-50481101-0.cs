    public static IEnumerable<T> GetUniqueFlags<T>(this Enum flags)
        where T : Enum    // New constraint for C# 7.3
    {
        ulong flag = 1;
        foreach (var value in Enum.GetValues(flags.GetType()).Cast<T>())
        {
            ulong bits = Convert.ToUInt64(value);
            while (flag < bits) 
                flag <<= 1; 
            if (flag == bits && flags.HasFlag(value as Enum)) 
                yield return value; 
        }
    }
