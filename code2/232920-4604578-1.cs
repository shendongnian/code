    //your DataTable, replace with table get code
    DataTable table = new DataTable();
    bool tableHasNull = false;
    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in table.Columns)
        {
            //test for null here
            if (row[col] == DBNull.Value)
            {
                tableHasNull = true;
            }
        }
    }
    if (tableHasNull)
    {
        //handle null in table
    }
