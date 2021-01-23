    public static void SaveList<T>(IEnumerable<T> itemsToSave) where T : class
    {
        foreach (T item in itemsToSave)
        {
            DatabaseInstance.Save(listItem);
        }
    }
    public static IEnumerable<T> LoadList<T>() where T : class
    {
        return (from index in DatabaseInstance.Query<T, int>()
                select index.Key);
    }
