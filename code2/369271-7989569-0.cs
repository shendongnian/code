    public static void SaveList<T>(List<T> listToSave) where T:class
    {
        foreach (T listItem in listToSave)
        {
            DatabaseInstance.Save(listItem);
        }
    }
