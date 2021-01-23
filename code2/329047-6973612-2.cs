    for (int tablesIndex = 0; tablesIndex < backupArr.Count; tablesIndex++)
    {
        var tables = backupArr[tablesIndex];
        if (selectedDatabase == tables.selDatabase && table == tables.selTable)
        {
            backupArr.RemoveAt(tablesIndex);
            tablesIndex--;
        }
    }
