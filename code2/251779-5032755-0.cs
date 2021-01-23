    bool isFirstReached = false;
    foreach (DataRow datarow in datatable.Rows)
    {
        foreach (DataColumn datacolumn in datarow.Table.Columns)
        {
            if (!isFirstReached)
            {
                isFirstReached = true;
                continue;
            }
        }
    }
