    int i;
    for (i = 0; i < backupArr.Count; i++)
    {
        DBTables tables = backupArr[i];
        if (selectedDatabase == tables.selDatabase && table == tables.selTable)
        {
            break;
        }
    }
    backupArr.RemoveAt(i);
