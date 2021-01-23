    public static void SaveArrayAsCSV(Array arrayToSave, string fileName)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {
            WriteItemsToFile(arrayToSave, file);
        }
    }
    private static void WriteItemsToFile(Array items, TextWriter file)
    {
        foreach (object item in items)
        {
            if (item is Array)
            {
                WriteItemsToFile(item as Array, file);
                file.Write(Environment.NewLine);
            }
            else file.Write(item + ",");   
        }
    }
