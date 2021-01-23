    public static Hashtable CreateHashtable(params object[] keysAndValues)
    {
        if ((keysAndValues.Length % 2) != 0)
        {
            throw new ArgumentException("Must have an even number of keys/values");
        }
        Hashtable ret = new Hashtable();
        for (int i = 0; i < keysAndValues.Length; i += 2)
        {
            ret[keysAndValues[i]] = keysAndValues[i + 1];
        }
        return ret;
    }
