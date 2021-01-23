    public static int GetVersion<T>(List<T> list)
    {
        return (int)list.GetType()
                     .GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic)
                     .GetValue(list);
    }
