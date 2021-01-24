    string[] tableNames = new string[]{"Table1", "Table2", ...};
    string[] tableColorProperties = new string[]{"Table1FillColor", "Table2FillColor", ...};
    for(int i=0; i<tableNames.Length; i++)
    {
        if (availableTables.Any(item => item.Name == tableNames[i]) == false)
        {
            ViewData.Add(tableColorProperties[i], "#ff1200");
        }
    }
