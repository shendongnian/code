    public static List<T> GetAllEnums<T>()
        where T : struct
    {
        if (typeof(T).BaseType != typeof(Enum)) throw new ArgumentException("T must be an Enum type");
        var values = Enum.GetValues(typeof(T)).Cast<int>().ToArray();
        var valuesInverted = values.Select(v => ~v).ToArray(); 
        var result = new List<T>();
        int max = 0;
        for (int i = 0; i < values.Length; i++)
        {
            max |= values[i];
        }
        for (int i = 0; i <= max; i++)
        {
            int unaccountedBits = i;
            for (int j = 0; j < valuesInverted.Length; j++)
            {
                unaccountedBits &= valuesInverted[j];
                if (unaccountedBits == 0)
                {
                    result.Add((T)(object)i);
                    break;
                }
            }
        }
        //Check for zero
        try
        {
            if (string.IsNullOrEmpty(Enum.GetName(typeof(T), (T)(object)0)))
            {
                result.Remove((T)(object)0);
            }
        }
        catch
        {
            result.Remove((T)(object)0);
        }
            
        return result;
    }
