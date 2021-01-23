    public static void SaveArrayAsCSV<T>(T[] arrayToSave, string fileName)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {
            foreach (T item in arrayToSave)
            {
                file.Write(item + ",");
            }
        }
    }
