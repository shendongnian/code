    private static void EnumerateObjects(Array items)
    {
        foreach (var item in items)
        {
            if (item is Array)
            {
                EnumerateObjects((Array)item);
            }
            else if (item is MyObject)
            {
                Console.WriteLine(item);
            }
        }
    }
