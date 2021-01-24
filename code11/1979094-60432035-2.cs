    public static DataTable ToDataTable(this string[][] items)
    {
        DataTable dataTable = new DataTable();
    
        int count = 0;
        foreach (var row in items)
        {
            if (count == 0)
            {
                dataTable.Columns.Add(row[0].ToString(), typeof(string));
                dataTable.Columns.Add(row[1].ToString(), typeof(int));
                dataTable.Columns.Add(row[2].ToString(), typeof(int));
            }
            else
            {
                dataTable.Rows.Add(row[0].ToString(), Convert.ToInt32(row[1].ToString()), Convert.ToInt32(row[2].ToString()));
            }
            count++;
        }
        return dataTable;
    }
